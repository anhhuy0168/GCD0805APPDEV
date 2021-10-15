using appdev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appdev.ViewModels
{
    public class TraineeAccountViewModels
    {
        public RegisterViewModel RegisterViewModels { get; set; }

        public TraineeUser Trainees { get; set; }

        public List<TraineeUser> GetTraineesInfo { get; set; }

        public ApplicationUser TraineeUsers { get; set; }

        public List<ApplicationUser> GetTraineeUsers { get; set; }
    }
}