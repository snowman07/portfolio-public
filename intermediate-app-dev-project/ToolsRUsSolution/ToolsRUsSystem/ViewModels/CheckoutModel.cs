using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsRUsSystem.ViewModels
{
    public class CheckoutModel
    {
        public int StockItemID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int Quantity { get; set; }
        public int QuantityOnHand { get; set; }
    }
}
