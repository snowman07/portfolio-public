using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ToolsRUsSystem.Entities
{

    internal partial class Customer
    {

        private string _EmailAddress;


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Rentals = new HashSet<Rental>();
        }

        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Customer last name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Customer last name is limited to 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Customer first name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Customer first name is limited to 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Customer address is required.")]
        [StringLength(75, MinimumLength = 1, ErrorMessage = "Customer address is limited to 75 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Customer city is required.")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Customer city is limited to 30 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "ProvinceID is required.")]
        [StringLength(2, MinimumLength = 1, ErrorMessage = "ProvinceID is limited to 2 characters.")]
        public string ProvinceID { get; set; }

        [Required(ErrorMessage = "Customer postal code is required.")]
        [StringLength(6, MinimumLength = 1, ErrorMessage = "Customer postal code is limited to 6 characters.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Customer phone number is required.")]
        [StringLength(12, MinimumLength = 1, ErrorMessage = "Customer phone number is limited to 12 characters.")]
        public string ContactPhone { get; set; }

        [StringLength(50, ErrorMessage = "Customer email address is limited to 50 characters.")]
        public string EmailAddress 
        {
            get { return _EmailAddress; }
            set { _EmailAddress = string.IsNullOrEmpty(value) ? null : value; } 
        }

        public bool AcceptableStatus { get; set; }

        public virtual Province Province { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
