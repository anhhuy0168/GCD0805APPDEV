using appdev.Models;
using appdev.Utils;
using appdev.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace appdev.Controllers
{
    [Authorize(Roles = Role.Manager)]
    public class StaffsController : Controller
    {
        private ApplicationDbContext _context;
        private ApplicationUserManager _userManager;

        public StaffsController()
        {
            _context = new ApplicationDbContext();
        }

        public StaffsController(ApplicationUserManager userManager)
        {
            _context = new ApplicationDbContext();
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult IndexTrainee()
        {
            var role = _context.Roles.SingleOrDefault(n => n.Name == Role.Trainee);

            List<TraineeAccountViewModels> viewModel = _context.TraineeUsers
                .GroupBy(u => u.Trainees, s => s.TraineeID)
                .Select(res => new TraineeAccountViewModels
                {
                    TraineeUsers = res.Key,
                    GetTraineeUsers = _context.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)).ToList(),
                }).ToList();
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult CreateTraineeAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateTraineeAccount(TraineeAccountViewModels viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                { UserName = viewModel.RegisterViewModels.Email, Email = viewModel.RegisterViewModels.Email };
                var result = await UserManager.CreateAsync(user, viewModel.RegisterViewModels.Password);
                var traineeId = user.Id;
                var newTrainee = new TraineeUser()
                {
                    TraineeID = traineeId,
                    Full_Name = viewModel.Trainees.Full_Name,
                    Age = viewModel.Trainees.Age,
                    DateOfBirth = viewModel.Trainees.DateOfBirth,
                    Education = viewModel.Trainees.Education
                };

                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, Role.Trainee);
                    _context.TraineeUsers.Add(newTrainee);
                    _context.SaveChanges();
                }
                AddErrors(result);
            }

            return RedirectToAction("IndexTrainee", "Staffs");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [HttpGet]
        public ActionResult EditTraineeAccount(string id)
        {
            var traineeInDb = _context.TraineeUsers.SingleOrDefault(u => u.TraineeID == id);
            if (traineeInDb == null)
            {
                return HttpNotFound();
            }
            return View(traineeInDb);
        }

        [HttpPost]
        public ActionResult EditTraineeAccount(TraineeUser trainee)
        {
            if (!ModelState.IsValid)
            {
                return View(trainee);
            }
            var traineeInfoInDb = _context.TraineeUsers.SingleOrDefault(t => t.TraineeID == trainee.TraineeID);

            if (traineeInfoInDb == null)
            {
                return HttpNotFound();
            }
            traineeInfoInDb.Full_Name = trainee.Full_Name;
            traineeInfoInDb.Age = trainee.Age;
            traineeInfoInDb.DateOfBirth = trainee.DateOfBirth;
            traineeInfoInDb.Education = trainee.Education;
            _context.SaveChanges();

            return RedirectToAction("IndexTrainee", "Staffs");
        }

        [HttpGet]
        public ActionResult DeleteTraineeAccount(string id)
        {
            var traineeInDb = _context.Users.SingleOrDefault(i => i.Id == id);
            var traineeInfoInDb = _context.TraineeUsers.SingleOrDefault(i => i.TraineeID == id);
            if (traineeInDb == null || traineeInfoInDb == null)
            {
                return HttpNotFound();
            }
            _context.Users.Remove(traineeInDb);
            _context.TraineeUsers.Remove(traineeInfoInDb);
            _context.SaveChanges();
            return RedirectToAction("IndexTrainee", "Staffs");
        }

        [HttpGet]
        public ActionResult TraineeInfoDetails(string id)
        {
            var traineeId = User.Identity.GetUserId();

            var traineeInfoInDb = _context.TraineeUsers
                .SingleOrDefault(t => t.TraineeID == id);

            if (traineeInfoInDb == null)
            {
                return HttpNotFound();
            }
            return View(traineeInfoInDb);
        }

        public ActionResult TraineePasswordReset(string id)
        {
            var traineeInDb = _context.Users.SingleOrDefault(i => i.Id == id);
            if (traineeInDb == null)
            {
                return HttpNotFound();
            }
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            userId = traineeInDb.Id;
            if (userId != null)
            {
                UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
                userManager.RemovePassword(userId);
                string newPassword = "DefaultPassword@123";
                userManager.AddPassword(userId, newPassword);
            }
            _context.SaveChanges();
            return RedirectToAction("IndexTrainee", "Staffs");
        }
    }
}