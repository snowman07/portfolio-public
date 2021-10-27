using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ToolsRUsSystem.Entities
{

    internal partial class Vendor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vendor()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            StockItems = new HashSet<StockItem>();
        }

        public int VendorID { get; set; }

        [Required(ErrorMessage = "Vendor name is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Vendor name is limited to 100 characters.")]
        public string VendorName { get; set; }

        [Required(ErrorMessage = "Vendor phone number is required.")]
        [StringLength(12, MinimumLength = 1, ErrorMessage = "Vendor phone number is limited to 12 characters.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Vendor address is required.")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Vendor address is limited to 30 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vendor city is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Vendor city is limited to 50 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "ProvinceID is required.")]
        [StringLength(2, MinimumLength = 1, ErrorMessage = "ProvinceID is limited to 2 characters.")]
        public string ProvinceID { get; set; }

        [Required(ErrorMessage = "Vendor postal code is required.")]
        [StringLength(6, MinimumLength = 1, ErrorMessage = "Vendor postal code is limited to 6 characters.")]
        public string PostalCode { get; set; }

        public virtual Province Province { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockItem> StockItems { get; set; }
    }
}
