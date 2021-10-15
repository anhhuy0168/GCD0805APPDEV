using appdev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appdev.ViewModels
{
    public class StaffAccountViewModels
    {
        public RegisterViewModel RegisterViewModels { get; set; }

        public Staff Staffs { get; set; }

        public List<Staff> GetStaffsInfo { get; set; }

        public ApplicationUser StaffUsers { get; set; }

        public List<ApplicationUser> GetStaffsUsers { get; set; }
    }
}