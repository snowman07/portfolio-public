using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ToolsRUsSystem.Entities
{

    internal partial class ReturnedOrderDetail
    {

        private string _ItemDescription;
        private string _VendorStockNumber;


        public int ReturnedOrderDetailID { get; set; }

        public int ReceiveOrderID { get; set; }

        public int? PurchaseOrderDetailID { get; set; }

        [StringLength(50, ErrorMessage = "Item description is limited to 50 characters.")]
        public string ItemDescription 
        {
            get { return _ItemDescription; }
            set { _ItemDescription = string.IsNullOrEmpty(value) ? null : value; } 
        }

        public int Quantity { get; set; }

        [Required(ErrorMessage = "Reason is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Reason is limited to 50 characters.")]
        public string Reason { get; set; }

        [StringLength(15, ErrorMessage = "Vendor stock number is limited to 15 characters.")]
        public string VendorStockNumber 
        {
            get { return _VendorStockNumber; }
            set { _VendorStockNumber = string.IsNullOrEmpty(value) ? null : value; } 
        }

        public virtual PurchaseOrderDetail PurchaseOrderDetail { get; set; }

        public virtual ReceiveOrder ReceiveOrder { get; set; }
    }
}
