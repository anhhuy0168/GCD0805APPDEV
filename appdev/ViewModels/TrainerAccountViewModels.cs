using appdev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appdev.ViewModels
{
    public class TrainerAccountViewModels
    {
        public RegisterViewModel RegisterViewModels { get; set; }

        public TrainerUser Trainers { get; set; }

        public List<TrainerUser> GetTrainerInfo { get; set; }

        public ApplicationUser TrainerUsers { get; set; }

        public List<ApplicationUser> GetTrainerUsers { get; set; }
    }
}