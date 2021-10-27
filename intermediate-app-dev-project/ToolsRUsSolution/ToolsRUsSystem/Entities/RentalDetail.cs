using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ToolsRUsSystem.Entities
{

    internal partial class RentalDetail
    {

        private string _Comments;


        public int RentalDetailID { get; set; }

        public int RentalID { get; set; }

        public int RentalEquipmentID { get; set; }

        public decimal RentalDays { get; set; }

        [Column(TypeName = "money")]
        public decimal RentalRate { get; set; }

        [Required(ErrorMessage = "Out condition is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Out condition is limited to 100 characters.")]
        public string OutCondition { get; set; }

        [Required(ErrorMessage = "In condition is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "In condition is limited to 100 characters.")]
        public string InCondition { get; set; }

        [Column(TypeName = "money")]
        public decimal DamageRepairCost { get; set; }

        [StringLength(500, ErrorMessage = "Comments is limited to 500 characters.")]
        public string Comments 
        {
            get { return _Comments; }
            set { _Comments = string.IsNullOrEmpty(value) ? null : value; } 
        }

        public virtual RentalEquipment RentalEquipment { get; set; }

        public virtual Rental Rental { get; set; }
    }
}
