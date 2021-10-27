using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespace
using ToolsRUsSystem.DAL;
using ToolsRUsSystem.Entities;
using ToolsRUsSystem.ViewModels;
using System.ComponentModel;
#endregion

namespace ToolsRUsSystem.BLL.Sales
{
    public class CheckoutController
    {

        public int Return_SalesID(string paymenttype, int employeeid, decimal taxamount, decimal subtotal, int? couponid, List<AddCartModel> saleDetails)
        {
            using (var context = new ToolsRUsSystemContext())
            {
                Sale newSale = new Sale()
                {
                    SaleDate = DateTime.Now,
                    PaymentType = paymenttype,
                    EmployeeID = employeeid,
                    SubTotal = subtotal,
                    CouponID = couponid,
                    TaxAmount = taxamount
                };

                context.Sales.Add(newSale);

                foreach (AddCartModel items in saleDetails)
                {
                    SaleDetail newItem = new SaleDetail()
                    {
                        StockItemID = items.StockItemID,
                        SellingPrice = items.SellingPrice,
                        Quantity = items.Quantity
                    };
                    newSale.SaleDetails.Add(newItem);

                    StockItem newStock = (from x in context.StockItems
                                          where x.StockItemID == items.StockItemID
                                          select x).FirstOrDefault();
                    newStock.QuantityOnHand = newStock.QuantityOnHand - items.Quantity;

                    context.Entry(newStock).Property(nameof(StockItem.QuantityOnHand)).IsModified = true;
                }

                return context.SaveChanges();
            }

        }

    }
}
