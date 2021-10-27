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
    public class SalesOrderController
    {

        //class level variable that will hold multiple strings, each representing
        //      an error message.
        List<Exception> brokenRules = new List<Exception>();


        //method for GridVIew of View Cart tab
        public List<ViewCartItem> List_ItemsToViewCart(int stockitemid)
        {
            using (var context = new ToolsRUsSystemContext())
            {
                var results = from x in context.StockItems
                              where x.StockItemID == stockitemid
                              select new ViewCartItem
                              {
                                  StockItemID = x.StockItemID,
                                  Description = x.Description,
                                  Price = x.SellingPrice
                              };
                return results.ToList();
            }
        }


        //public void Add_ItemToCart(int stockitemid, string description, string sellingprice)
        //{
        //    using (var context = new ToolsRUsSystemContext())
        //    {
        //        //logic goes here for add

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
                                            //Quantity = 1,
                                            Price = x.SellingPrice,
                                            Description = x.Description,
                                            Total = x.SellingPrice * quantity,
                                            //QuantityOnHand = x.QuantityOnHand

                                        }).FirstOrDefault();
                return results;

            }
        }

    }
}
