using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsRUsSystem.ViewModels
{
    public class POList
    {
        public int PurchaseOrderID { get; set; }
        public int EmployeeID { get; set; }
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string Phone { get; set; }
        public DateTime? OrderDate { get; set; }

    }
}
