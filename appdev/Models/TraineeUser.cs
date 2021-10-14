using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appdev.Models
{
    public class TraineeUser
    {
        public int ID { get; set; }
        [Required]
        public string TraineeID { get; set; }
        [StringLength(255)]
        public string Full_Name { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Age { get; set; }
        [StringLength(255)]
        public string DateOfBirth { get; set; }
        [StringLength(255)]
        public string Education { get; set; }
        //public int Phone { get; set; }
        public ApplicationUser Trainees { get; set; }




	}
}