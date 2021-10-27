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
    [DataObject]
    public class StockItemController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<StockItemList> List_StockItemFromCategorySelection (int? categoryid)
        {
            using (var context = new ToolsRUsSystemContext())
            { 
                if (categoryid != null)
                {
                    IEnumerable<StockItemList> results = from x in context.StockItems
                                                         where x.CategoryID == categoryid
                                                         && x.Discontinued.Equals(false)
                                                         orderby x.Description
                                                         select new StockItemList
                                                         {
                                                             StockItemID = x.StockItemID,
                                                             Description = x.Description,
                                                             SellingPrice = x.SellingPrice,
                                                             QuantityOnHand = x.QuantityOnHand,
                                                             //Count = (from y in context.StockItems
                                                             //         where y.CategoryID == categoryid
                                                             //         && y.Discontinued.Equals(false)
                                                             //        select y.StockItemID).Count()
                                                             Count = 1
                                                         };
                    return results.ToList();
                }
                else
                {
                    IEnumerable<StockItemList> results = from x in context.StockItems
                                                         where x.CategoryID.Equals(x.CategoryID)
                                                         && x.Discontinued.Equals(false)
                                                         orderby x.Description
                                                         select new StockItemList
                                                         {
                                                             StockItemID = x.StockItemID,
                                                             Description = x.Description,
                                                             SellingPrice = x.SellingPrice,
                                                             QuantityOnHand = x.QuantityOnHand,
                                                             //Count = (from y in context.StockItems
                                                             //         where y.CategoryID == categoryid
                                                             //         && y.Discontinued.Equals(false)
                                                             //         select y.StockItemID).Count()
                                                             Count = 1
                                                         };
                    return results.ToList();
                }

            }
        }

        //[DataObjectMethod(DataObjectMethodType.Select, false)]
        //public List<StockItem> StockItems_List()
        //{
        //    //create an transaction instance of Context class
        //    using (var context = new ToolsRUsSystemContext())
        //    {
        //        return context.StockItems.OrderBy(x => x.Description).ToList();
        //    }
        //}

        //[DataObjectMethod(DataObjectMethodType.Select, false)]
        //public StockItem StockItems_Get(int stockitemid)
        //{
        //    using (var context = new ToolsRUsSystemContext())
        //    {
        //        return context.StockItems.Find(stockitemid);
        //    }
        //}

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ViewCartItem Items_GetByStockItemID(int stockitemid, int quantity)
        {
            using (var context = new ToolsRUsSystemContext())
            {
                ViewCartItem results = (from x in context.StockItems
                                        where x.StockItemID == stockitemid
                                        select new ViewCartItem
                                        {
                                            StockItemID = x.StockItemID,
                                            Quantity = 1,
                                            Price = x.SellingPrice,
                                            Description = x.Description,
                                            Total = x.SellingPrice * quantity,
                                            QuantityOnHand = x.QuantityOnHand

                                        }).FirstOrDefault();
                return results;

            }
        }





    }
}
