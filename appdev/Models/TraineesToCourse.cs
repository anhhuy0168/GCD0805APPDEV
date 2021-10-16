using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appdev.Models
{
    public class TraineesToCourse
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        public TraineeUser Trainee { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}