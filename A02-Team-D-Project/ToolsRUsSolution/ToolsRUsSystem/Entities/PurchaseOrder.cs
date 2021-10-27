using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ToolsRUsSystem.Entities
{

    internal partial class PurchaseOrder
    {

        private string _Notes;


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrder()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
            ReceiveOrders = new HashSet<ReceiveOrder>();
        }

        public int PurchaseOrderID { get; set; }

        public DateTime? OrderDate { get; set; }

        public int VendorID { get; set; }

        public int EmployeeID { get; set; }

        [Column(TypeName = "money")]
        public decimal TaxAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal SubTotal { get; set; }

        public bool Closed { get; set; }

        [StringLength(100, ErrorMessage = "Notes is limited to 100 characters. ")]
        public string Notes 
        {
            get { return _Notes; }
            set { _Notes = string.IsNullOrEmpty(value) ? null : value; } 
        }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        public virtual Vendor Vendor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReceiveOrder> ReceiveOrders { get; set; }
    }
}
