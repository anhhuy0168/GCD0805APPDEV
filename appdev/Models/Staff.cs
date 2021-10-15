using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appdev.Models
{
    public class Staff
    {
        [Key]
        [ForeignKey("User")]
        //khoa ngoai vs bang user
        public string StaffId { get; set; }

        public ApplicationUser User { get; set; }

        //for validation
        [Required]
        [StringLength(255)]

        public string FullName { get; set; }
        [Required]
        [StringLength(255)]

        public string Age { get; set; }
        [Required]
        [StringLength(255)]

        public string Address { get; set; }
    }
}