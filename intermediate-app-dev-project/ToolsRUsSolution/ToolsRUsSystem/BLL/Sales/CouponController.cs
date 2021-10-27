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
    public class CouponController
    {

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SelectionListCategory> Category_DDL()
        {
            using (var context = new ToolsRUsSystemContext())
            {
                IEnumerable<SelectionListCategory> results = from x in context.Coupons
                                                     orderby x.CouponIDValue
                                                     select new SelectionListCategory
                                                     {
                                                         ValueField = x.CouponID,
                                                         DisplayField = x.CouponIDValue
                                                     };
                return results.ToList();
            }
        }

    }
}
