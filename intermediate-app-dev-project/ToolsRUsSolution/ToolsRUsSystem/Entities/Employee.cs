using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ToolsRUsSystem.Entities
{

    internal partial class Employee
    {

        private string _LoginID;


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            ReceiveOrders = new HashSet<ReceiveOrder>();
            Rentals = new HashSet<Rental>();
            SaleRefunds = new HashSet<SaleRefund>();
            Sales = new HashSet<Sale>();
        }

        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Employee first name is required.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Employee first name is limited to 25 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Employee lasst name is required.")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Employee last name is limited to 25 characters.")]
        public string LastName { get; set; }

        public DateTime DateHired { get; set; }

        public DateTime? DateReleased { get; set; }

        public int PositionID { get; set; }

        [StringLength(30, ErrorMessage = "LoginID is limited to 30 characters.")]
        public string LoginID 
        {
            get { return _LoginID; }
            set { _LoginID = string.IsNullOrEmpty(value) ? null : value; } 
        }

        [Required(ErrorMessage = "Employee address is required.")]
        [StringLength(75, MinimumLength = 1, ErrorMessage = "Employee address is limited to 75 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Employee city is required.")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Employee city is limited to 30 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Employee phone number is required.")]
        [StringLength(12, MinimumLength = 1, ErrorMessage = "Employee phone number is limited to 12 characters.")]
        public string ContactPhone { get; set; }

        [Required(ErrorMessage = "Employee postal code is required.")]
        [StringLength(6, MinimumLength = 1, ErrorMessage = "Employess postal code is limited to 6 characters.")]
        public string PostalCode { get; set; }

        public virtual Position Position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReceiveOrder> ReceiveOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rental> Rentals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleRefund> SaleRefunds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
