using appdev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appdev.ViewModels
{
    public class AssignTraineeToCourseViewModel
    {
        public int CourseId { get; set; }
        public List<Course> Courses { get; set; }
        public int TraineeId { get; set; }
        public List<TraineeUser> Trainees { get; set; }
        public Course Course { get; set; }

    }
}