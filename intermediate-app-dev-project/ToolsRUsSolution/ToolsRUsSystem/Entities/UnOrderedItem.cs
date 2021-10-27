using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ToolsRUsSystem.Entities
{

    internal partial class UnOrderedItem
    {
        [Key]
        public int ItemID { get; set; }

        [Required(ErrorMessage = "Item name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Item name is limited 50 characters.")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Vendor product ID is required.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Vendor product ID is limited 25 characters.")]
        public string VendorProductID { get; set; }

        public int Quantity { get; set; }
    }
}
