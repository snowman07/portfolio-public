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
    public class CategoryController
    {

        #region To populate the DDL of categories in Shopping tab 
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SelectionListCategory> Categories_DDL()
        {
            using (var context = new ToolsRUsSystemContext())
            {
                IEnumerable<SelectionListCategory> results = from x in context.Categories
                                                             orderby x.Description
                                                             select new SelectionListCategory
                                                             {
                                                                 ValueField = x.CategoryID,
                                                                 DisplayField = x.Description
                                                             };
                return results.ToList();

            }
        }
        #endregion


    }
}
