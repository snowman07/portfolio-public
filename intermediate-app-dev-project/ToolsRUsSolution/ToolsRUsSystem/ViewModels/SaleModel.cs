using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsRUsSystem.ViewModels
{
    public class SaleModel
    {
        public int StockItemID { get; set; }
        public string Description { get; set; }
        public int OriginalQuantity { get; set; }
        public decimal Price { get; set; }
        public int ReturnQuantity { get; set; }
        public int Quantity { get; set; }
        public decimal Sales { get; set; }
        public decimal Tax { get; set; }
        public int Coupon { get; set; }
    }
}
