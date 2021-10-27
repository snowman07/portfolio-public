using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsRUsSystem.ViewModels
{
    public class AddCartModel
    {
        public int StockItemID { get; set; }
        public decimal SellingPrice { get; set; }
        public int Quantity { get; set; }

    }
}
