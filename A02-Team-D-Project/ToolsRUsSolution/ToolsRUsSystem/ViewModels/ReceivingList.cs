using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsRUsSystem.ViewModels
{
    public class ReceivingList
    {
        public int PurchaseOrderID { get; set; }
        public int PurchaseOrderDetail { get; set; }
        public int SID { get; set; }
        public string Description { get; set; }
        public int Ordered { get; set; }
        private int? _Outstanding;
        public int? Outstanding
        {
            get{return _Outstanding;}
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                { _Outstanding = Ordered; }
                else{ _Outstanding = value; }
            }
        }
        public int? Receive { get; set; }
        public int? Return { get; set; }
        public string Reason { get; set; }
        public int QOS { get; set; }
        public int QtyO { get; set; }
        public int CategoryID { get; set; }
    }
}
