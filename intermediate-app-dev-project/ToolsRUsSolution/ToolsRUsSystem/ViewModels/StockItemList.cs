using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsRUsSystem.ViewModels
{
    public class StockItemList
    {
        public int StockItemID { get; set; }
        public string Description { get; set; }
        public decimal SellingPrice { get; set; }
        public int QuantityOnHand { get; set; }
        public int Count { get; set; }
    }
}
