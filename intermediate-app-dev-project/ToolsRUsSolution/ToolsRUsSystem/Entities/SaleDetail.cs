using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ToolsRUsSystem.Entities
{

    internal partial class SaleDetail
    {
        public int SaleDetailID { get; set; }

        public int SaleID { get; set; }

        public int StockItemID { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal SellingPrice { get; set; }

        public int Quantity { get; set; }

        public virtual Sale Sale { get; set; }

        public virtual StockItem StockItem { get; set; }
    }
}
