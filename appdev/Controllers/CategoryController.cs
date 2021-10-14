using appdev.Models;
using System.Linq;
using System.Web.Mvc;

namespace GCD0805AppDev.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context1;
        public CategoriesController()
        {
            _context1 = new ApplicationDbContext();
        }
        [HttpGet]
        public ActionResult Index()
        {
            var category = _context1.Category.ToList();
            return View(category);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            var check = _context1.Category.Any(
                c => c.Name.Contains(category.Name));
            if (check)
            {
                ModelState.AddModelError("", "Category Already Exists.");
                return View("Create");
            }
            _context1.Category.Add(category);
            _context1.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var categoryInDb = _context1.Category.SingleOrDefault(c => c.ID == id);
            if (categoryInDb == null)
            {
                return HttpNotFound();
            }

            return View(categoryInDb);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            var categoryInDb = _context1.Category.SingleOrDefault(c => c.ID == category.ID);
            if (categoryInDb == null)
            {
                return HttpNotFound();
            }
            categoryInDb.Name = category.Name;
            categoryInDb.Description = category.Description;
            _context1.SaveChanges();

            return RedirectToAction("Index", "Categories");
        }
        [HttpGet]

        public ActionResult Delete(int id)
        {
            var categoryInDb = _context1.Category.SingleOrDefault(c => c.ID == id);

            if (categoryInDb == null)
            {
                return HttpNotFound();
            }

            _context1.Category.Remove(categoryInDb);
            _context1.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}