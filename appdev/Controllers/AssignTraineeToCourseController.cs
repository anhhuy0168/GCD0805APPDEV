using appdev.Models;
using appdev.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appdev.Controllers
{
    public class AssignTraineeToCourseController : Controller
    {
        private ApplicationDbContext _context;
        public AssignTraineeToCourseController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: AssignTraineeToCourse
        [HttpGet]
        public ActionResult Index(string SearchCourse)
        {
            List<AssignTraineeToCourseViewModel> viewModel = _context.TraineesToCourses
                .GroupBy(i => i.Course)
                .Select(res => new AssignTraineeToCourseViewModel
                {
                    Course = res.Key,
                    Trainees = res.Select(u => u.Trainee).ToList()
                })
                .ToList();
            if (!string.IsNullOrEmpty(SearchCourse))
            {
                viewModel = viewModel
                    .Where(t => t.Course.Name.ToLower().Contains(SearchCourse.ToLower())).
                    ToList();
            }
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult AddTrainee()
        {
            var viewModel = new AssignTraineeToCourseViewModel
            {
                Courses = _context.Courses.ToList(),
                Trainees = _context.TraineeUsers.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult AddTrainee(AssignTraineeToCourseViewModel viewModel)
        {
            var model = new TraineesToCourse
            {
                CourseId = viewModel.CourseId,
                TraineeId = viewModel.TraineeId
            };
            _context.TraineesToCourses.Add(model);
            _context.SaveChanges();

            return RedirectToAction("GetTrainees", "Courses");
        }
    }
}