using appdev.Models;
using appdev.Utils;
using appdev.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace appdev.Controllers
{
	[Authorize(Roles = Role.Manager)]
	public class TraineeUsersController : Controller
	{


		private ApplicationDbContext _context;
		public TraineeUsersController()
		{
			_context = new ApplicationDbContext();
		}
		// GET: Trainees
		[HttpGet]
		public ActionResult Index(string searchString)
		{
			var trainee = _context.TraineeUsers.Include(te => te.Trainees);
			if (!String.IsNullOrEmpty(searchString))
			{
				trainee = trainee.Where(s => s.Trainees.UserName.Contains(searchString));
				return View(trainee);
			}

			if (User.IsInRole(Role.Manager))
			{
				var viewTrainee = _context.TraineeUsers.Include(a => a.Trainees).ToList();
				return View(viewTrainee);
			}
			/*	if (User.IsInRole("Trainee"))
				{
					var traineeId = User.Identity.GetUserId();
					var traineeVM = _context.TraineeUsers.Where(te => te.TraineeID == traineeId).ToList();
					return View(traineeVM);
				}*/
			return View("Index");

		}
		// CREATE
		[HttpGet]
		public ActionResult Create()
		{
			//Get Account Trainee
			var userInDb = (from r in _context.Roles where r.Name.Contains("trainee") select r).FirstOrDefault();
			var users = _context.Users.Where(u => u.Roles.Select(us => us.RoleId).Contains(userInDb.Id)).ToList();
			var traineeUser = _context.TraineeUsers.ToList();
			var viewModel = new TraineeUserViewModel
			{
				Trainees = users,
				TraineeUser = new TraineeUser()
			};
			return View(viewModel);
		}
		[HttpPost]
		public ActionResult Create(TraineeUserViewModel trainee)
		{
			var traineeinDb = (from te in _context.Roles where te.Name.Contains("trainee") select te).FirstOrDefault();
			var traineeUser = _context.Users.Where(u => u.Roles.Select(us => us.RoleId).Contains(traineeinDb.Id)).ToList();
			if (ModelState.IsValid)
			{

				var checkTraineeExist = _context.TraineeUsers.Include(t => t.Trainees).Where(t => t.Trainees.Id == trainee.TraineeUser.TraineeID);
				//GET TraineeID 
				if (checkTraineeExist.Count() > 0)  //list ID comparison, if count == 0. jump to else
													// if (checkTraineeExist.Any())
				{
					ModelState.AddModelError("", "Trainee Already Exists.");
				}
				else
				{
					_context.TraineeUsers.Add(trainee.TraineeUser);
					_context.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			TraineeUserViewModel traineeUserView = new TraineeUserViewModel()
			{
				Trainees = traineeUser,
				TraineeUser = trainee.TraineeUser
			};
			return View(traineeUserView);
		}


		[HttpGet]
		public ActionResult Edit(int id)
		{
			var traineeInDb = _context.TraineeUsers.SingleOrDefault(te => te.ID == id);
			if (traineeInDb == null)
			{
				return HttpNotFound();
			}
			return View(traineeInDb);
		}

		[HttpPost]
		public ActionResult Edit(TraineeUser traineeUser)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			var traineeInDb = _context.TraineeUsers.SingleOrDefault(te => te.ID == traineeUser.ID);
			if (traineeInDb == null)
			{
				return HttpNotFound();
			}
			traineeInDb.Email = traineeUser.Email;
			traineeInDb.Full_Name = traineeUser.Full_Name;
			traineeInDb.Age = traineeUser.Age;
			traineeInDb.DateOfBirth = traineeUser.DateOfBirth;
			traineeInDb.Education = traineeUser.Education;
			//traineeInDb.Phone = traineeUser.Phone;
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Delete(int id)
		{
			var traineeInDb = _context.TraineeUsers.SingleOrDefault(te => te.ID == id);
			if (traineeInDb == null)
			{
				return HttpNotFound();
			}
			_context.TraineeUsers.Remove(traineeInDb);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}