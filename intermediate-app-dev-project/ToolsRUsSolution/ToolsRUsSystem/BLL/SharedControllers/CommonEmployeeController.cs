using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using System.ComponentModel;
using ToolsRUsSystem.DAL;
#endregion

namespace ToolsRUsSystem.BLL.SharedControllers
{
    [DataObject]
    public class CommonEmployeeController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public string GetEmployeeName(int employeeID)
        {
            using (var context = new ToolsRUsSystemContext())
            {
                string results = context.Employees.Where(x => (x.EmployeeID == employeeID))
                                    .Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();

                return results;
            }

        }
    }

}
