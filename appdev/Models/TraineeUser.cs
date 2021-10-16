using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appdev.Models
{
    public class TraineeUser
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("User")]
        //khoa ngoai vs bang user
        public string TraineeId { get; set; }

        public ApplicationUser User { get; set; }

        //for validation
        [Required(ErrorMessage = "Please enter Trainee Name")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Trainee Name Should Between 4 to 30 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter Trainee Age")]
        [Range(18, 30, ErrorMessage = "Trainee Age Should Between 18 to 30")]
        public int Age { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter Trainee Education")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Trainee Education Should At least 4 to 30 characters")]
        public string Education { get; set; }



    }
}