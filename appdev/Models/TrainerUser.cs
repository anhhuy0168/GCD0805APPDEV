using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appdev.Models
{
    public class TrainerUser
    {
        [Key]
        [ForeignKey("User")]
        //khoa ngoai vs bang user
        public string TrainerId { get; set; }

        public ApplicationUser User { get; set; }

        //for validation
        [Required(ErrorMessage = "Please enter Trainer Name")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Trainer Name Should Between 4 to 30 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter Trainer Age")]
        [Range(25, 80, ErrorMessage = "Trainer Age Should Between 25 to 80")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter Trainer Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter Trainer Specialty")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Trainer Specialty Should At least 4 to 30 characters")]
        public string Specialty { get; set; }
    }
}