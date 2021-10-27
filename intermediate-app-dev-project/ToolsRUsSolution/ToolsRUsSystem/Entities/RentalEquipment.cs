using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ToolsRUsSystem.Entities
{

    [Table("RentalEquipment")]
    internal partial class RentalEquipment
    {

        private string _Condition;


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RentalEquipment()
        {
            RentalDetails = new HashSet<RentalDetail>();
        }

        public int RentalEquipmentID { get; set; }

        [Required(ErrorMessage = "Model number is required.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Model number is limited to 20 characters.")]
        public string ModelNumber { get; set; }

        [Required(ErrorMessage = "Serial number is required.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Serial number is limited to 20 characters.")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "Rental equipment description is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Rental equipment description is limited to 50 characters.")]
        public string Description { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal DailyRate { get; set; }

        [StringLength(100, ErrorMessage = "Rental equipment condition is limited to 100 characters.")]
        public string Condition 
        {
            get { return _Condition; }
            set { _Condition = string.IsNullOrEmpty(value) ? null : value; } 
        }

        public bool Available { get; set; }

        public bool Retired { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RentalDetail> RentalDetails { get; set; }
    }
}
