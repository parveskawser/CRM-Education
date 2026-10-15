using CRM.Entities;
using CRM.Facade.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseFacade _courseFacade;

        public CoursesController(ICourseFacade courseFacade)
        {
            _courseFacade = courseFacade;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _courseFacade.GetCoursesAsync();
            return View(courses);
        }

        //public IActionResult Index(int page = 0)
        //{
        //    int pageno = 0;

        //    //if(page <= pageno)
        //    //    pageno = 1; 
        //    //else
        //    //    pageno = page;

        //    pageno = (page <= pageno) ? 1 : page;


        //    ViewBag.pageno = pageno;

        //    //Model

        //    //List<Course> listCourse = new List<Course>();
        //    //listCourse.Add(new Course()
        //    //{
        //    //    Title="Bangla"
        //    //});
        //    //listCourse.Add(new Course()
        //    //{
        //    //    Title = "English"
        //    //});
        //    var courses = Courses;

        //    return View(courses);
        //}

        public IActionResult Detail(int id)
        {
            var course = _courseFacade.GetCourseByIdAsync(id);

            //var course = Courses.FirstOrDefault(x => x.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        

        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", course);
            }

            // পরে এখানে Database-এ Save করবেন
            // _context.Courses.Add(course);
            // _context.SaveChanges();

            return RedirectToAction("List");
        }
         
    }
}