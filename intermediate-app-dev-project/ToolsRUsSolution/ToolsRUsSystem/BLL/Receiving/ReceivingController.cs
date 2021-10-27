using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsRUsSystem.DAL;
using ToolsRUsSystem.Entities;
using ToolsRUsSystem.ViewModels;

namespace ToolsRUsSystem.BLL.Receiving
{
    [DataObject]
    public class ReceivingController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<POList> PORecieveOrders()

        {
            using (var context = new ToolsRUsSystemContext())
            {
                var results = from x in context.PurchaseOrders
                              orderby x.OrderDate
                              where x.Closed.Equals(false)
                              select new POList
                              {
                                  PurchaseOrderID = x.PurchaseOrderID,
                                  EmployeeID = x.EmployeeID,
                                  VendorID = x.VendorID,
                                  VendorName = x.Vendor.VendorName,
                                  Phone = x.Vendor.Phone,
                                  OrderDate = x.OrderDate
                              };

                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<ReceivingList> PODetail(int poID)
        {
            using (var context = new ToolsRUsSystemContext())
            {
                var results = from x in context.PurchaseOrderDetails
                              orderby x.StockItemID
                              where x.PurchaseOrderID == poID
                              select new ReceivingList
                              {
                                  PurchaseOrderID = x.PurchaseOrderID,
                                  PurchaseOrderDetail = x.PurchaseOrderDetailID,
                                  SID = x.StockItemID,
                                  Description = x.StockItem.Description,
                                  QtyO = x.StockItem.QuantityOnOrder,
                                  Ordered = x.Quantity,
                                  CategoryID = x.StockItem.CategoryID,
                                  QOS = x.StockItem.QuantityOnHand,
                                  Outstanding = x.Quantity - (int?)(from y in x.ReceiveOrderDetails
                                                                    select y.QuantityReceived).Sum(),
                              };
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<UnOrderedList> UnOrderedItemsSelect()
        {
            using (var context = new ToolsRUsSystemContext())
            {
                var results = from x in context.UnOrderedItems
                              orderby x.ItemID
                              select new UnOrderedList
                              {
                                  CID = x.ItemID,
                                  Description = x.ItemName,
                                  VSN = x.VendorProductID,
                                  Qty = x.Quantity
                              };

                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public void UnOrderedItemsAdd(UnOrderedList item)
        {
            using (var context = new ToolsRUsSystemContext())
            {
                UnOrderedItem addItem = new UnOrderedItem
                {
                    ItemName = item.Description,
                    VendorProductID = item.VSN,
                    Quantity = item.Qty
                };
                context.UnOrderedItems.Add(addItem);
                context.SaveChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void UnOrderedItemsDelete(UnOrderedList item)
        {
            UnOrderedItemsDelete(item.CID);
        }

        public void UnOrderedItemsDelete(int cid)
        {
            using (var context = new ToolsRUsSystemContext())
            {
                var exists = context.UnOrderedItems.Find(cid);
                context.UnOrderedItems.Remove(exists);
                context.SaveChanges();
            }
        }

        public void ReceiveReturnReasonTransaction(bool checkOutstanding, int poID, List<ReceivingList> ReceivingList1)
        {
            using (var context = new ToolsRUsSystemContext())
            {
                foreach (var item in ReceivingList1)
                {
                    var newstockItem = context.StockItems.Find(item.SID);

                    newstockItem.QuantityOnHand += (item.Receive).GetValueOrDefault();
                    newstockItem.QuantityOnOrder -= (item.Receive).GetValueOrDefault();

                    context.SaveChanges();
                }

                CreateReceiveOrder(poID, ReceivingList1);

                PurchaseOrder po = context.PurchaseOrders.Find(poID);

                if (checkOutstanding)
                {
                    po.Closed = true;
                    context.SaveChanges();
                }
            }
        }

        private void CreateReceiveOrder(int poID, List<ReceivingList> receivingList1)
        {
            using (var context = new ToolsRUsSystemContext())
            {
                ReceiveOrder ReceiveOrder1 = new ReceiveOrder
                {
                    PurchaseOrderID = poID,
                    ReceiveDate = DateTime.Now
                };

                context.ReceiveOrders.Add(ReceiveOrder1);
                context.SaveChanges();

                var lastReceivedOrder = (   from x in context.ReceiveOrders
                                            select x).ToList();
                ReceiveOrder ReceiveOrder2 = lastReceivedOrder.LastOrDefault();

                ReturnedOrderDetails(ReceiveOrder2.ReceiveOrderID, receivingList1);
                ReceiveOrderDetails(ReceiveOrder2.ReceiveOrderID, receivingList1);
            }
        }

        private void ReceiveOrderDetails(int receiveOrderID, List<ReceivingList> receivingList1)
        {
            using (var context = new ToolsRUsSystemContext())
            {
                foreach (var item in receivingList1)
                {
                    ReceiveOrderDetail newReceiveOrderDetail = new ReceiveOrderDetail
                    {
                        ReceiveOrderID = receiveOrderID,
                        PurchaseOrderDetailID = item.PurchaseOrderDetail,
                        QuantityReceived = item.Receive.GetValueOrDefault()
                    };

                    if (item.Outstanding > 0 && item.Receive != 0)
                    {
                        context.ReceiveOrderDetails.Add(newReceiveOrderDetail);
                    }
                }

                context.SaveChanges();
            }
        }

        private void ReturnedOrderDetails(int receiveOrderID, List<ReceivingList> receivingList1)
        {
            using (var context = new ToolsRUsSystemContext())
            {
                foreach (var item in receivingList1)
                {
                    if (item.Return > 0)
                    {
                        var sid = context.StockItems.Find(item.SID);
                        ReturnedOrderDetail ReturnedOrderDetail1 = new ReturnedOrderDetail
                        {
                            ReceiveOrderID = receiveOrderID,
                            PurchaseOrderDetailID = item.PurchaseOrderDetail,
                            ItemDescription = sid.Description,
                            VendorStockNumber = sid.VendorStockNumber,
                            Reason = item.Reason,
                            Quantity = item.Return.GetValueOrDefault()
                        };

                        context.ReturnedOrderDetails.Add(ReturnedOrderDetail1);
                    }
                }

                context.SaveChanges();
            }
        }

        public void ForceCloseOrder(int PurchaseOrderID, string reason)
        {
            using (var context = new ToolsRUsSystemContext())
            {
                PurchaseOrder getPurchaseOrder = context.PurchaseOrders.Find(PurchaseOrderID);
                getPurchaseOrder.Notes = reason;
                getPurchaseOrder.Closed = true;
                context.SaveChanges();
            }
        }

    }
}
