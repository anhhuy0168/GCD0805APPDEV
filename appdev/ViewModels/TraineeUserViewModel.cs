using appdev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appdev.ViewModels
{
    public class TraineeUserViewModel
    {
        public TraineeUser TraineeUser { get; set; }
        public IEnumerable<ApplicationUser> Trainees { get; set; }
    }
}