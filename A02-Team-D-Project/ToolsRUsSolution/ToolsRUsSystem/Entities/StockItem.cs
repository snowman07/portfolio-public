using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ToolsRUsSystem.Entities
{

    internal partial class StockItem
    {

        private string _VendorStockNumber;


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StockItem()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
            SaleDetails = new HashSet<SaleDetail>();
            SaleRefundDetails = new HashSet<SaleRefundDetail>();
        }

        public int StockItemID { get; set; }

        [Required(ErrorMessage = "Stock item description is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Stock Item description is limited to 50 characters.")]
        public string Description { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal SellingPrice { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal PurchasePrice { get; set; }

        public int QuantityOnHand { get; set; }

        public int QuantityOnOrder { get; set; }

        public int ReOrderLevel { get; set; }

        public bool Discontinued { get; set; }

        public int VendorID { get; set; }

        [StringLength(25, ErrorMessage = "Vendor stock number is limited to 25 characters.")]
        public string VendorStockNumber 
        {
            get { return _VendorStockNumber; }
            set { _VendorStockNumber = string.IsNullOrEmpty(value) ? null : value; } 
        }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleRefundDetail> SaleRefundDetails { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
