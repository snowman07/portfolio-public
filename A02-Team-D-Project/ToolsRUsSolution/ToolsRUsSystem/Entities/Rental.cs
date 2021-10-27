using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ToolsRUsSystem.Entities
{

    internal partial class Rental
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rental()
        {
            RentalDetails = new HashSet<RentalDetail>();
        }

        public int RentalID { get; set; }

        public int CustomerID { get; set; }

        public int EmployeeID { get; set; }

        public int? CouponID { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal SubTotal { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal TaxAmount { get; set; }

        public DateTime RentalDateOut { get; set; }

        public DateTime RentalDateIn { get; set; }

        [Required(ErrorMessage = "Payment type is required.")]
        [StringLength(1, ErrorMessage = "Payment type is limited to 1 character.")]
        public string PaymentType { get; set; }

        public virtual Coupon Coupon { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RentalDetail> RentalDetails { get; set; }
    }
}
