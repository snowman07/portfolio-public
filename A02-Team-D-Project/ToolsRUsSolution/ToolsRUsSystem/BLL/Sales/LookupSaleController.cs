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
    public class LookupSaleController
    {
        public class LookupSale
        {
            [DataObjectMethod(DataObjectMethodType.Select, false)]
            public List<SaleModel> Items_GetBySale(int saleid)
            {
                using (var context = new ToolsRUsSystemContext())
                {
                    IEnumerable<SaleModel> results = from x in context.SaleDetails
                                                     where x.SaleID == saleid
                                                     select new SaleModel
                                                     {
                                                         StockItemID = x.StockItemID,
                                                         Description = x.StockItem.Description,
                                                         Quantity = x.Quantity,
                                                         Price = x.SellingPrice,
                                                         Sales = x.Sale.SubTotal,
                                                         Tax = x.Sale.TaxAmount,
                                                         Coupon = x.Sale.Coupon.CouponDiscount
                                                     };
                    return results.ToList();
                }
            }
        }
    }
}
