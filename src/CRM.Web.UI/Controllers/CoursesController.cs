using CRM.Entities;
using CRM.Facade.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CRM.Framework;

namespace CRM.Web.UI.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly ICourseFacade _courseFacade; 
        private readonly IInstructorProfileFacade _instructorProfileFacade;

        public CoursesController(ICourseFacade courseFacade, IInstructorProfileFacade instructorProfileFacade)
        {
            _courseFacade = courseFacade;
            _instructorProfileFacade = instructorProfileFacade;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //courses
            var courses = await _courseFacade.GetCoursesAsync();

            //Course course = new Course();
            //List<Course> list = new List<Course>();

            //Dummy code 
            int idvalue = 500; // no change get zero

            string invoiceno = "INV00" + idvalue.ToString();//Failed
            //INV00500
             
            string ainvoiceno = $"INV{idvalue:D5}";
            //INV00500

            string finalInvoiceNo = idvalue.ToInvoiceNo();


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

        public async Task<IActionResult> Detail(int id)
        {
            var course =  await _courseFacade.GetCourseByIdAsync(id);

            //var course = Courses.FirstOrDefault(x => x.Id == id);

            if (course == null)
            {
                return NotFound();
            }
            
            var instructorList = await _instructorProfileFacade
      .GetInstructorProfilesAsync();

            ViewBag.Instructors = new SelectList(
                instructorList,
                "UserId",
                "Expertise",
                course.InstructorId
            );

            return View(course);
        }


        [HttpGet]
        public async Task<IActionResult> AddCourse(int id)
        {
            Course course = await _courseFacade.GetCourseByIdAsync(id);

            if(course == null)
                course = new Course();
            
            
            var instructorList = await _instructorProfileFacade.GetInstructorProfilesAsync();

            ViewBag.Instructors = new SelectList(
                instructorList,
                "UserId",
                "Bio"
            ); 

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCourse(Course course)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("AddCourse", course);
            //}
            try
            {
                if (course.CourseId > 0)
                    _courseFacade.UpdateCourseAsync(course);
                else
                    _courseFacade.AddCourseAsync(course);
            }
            catch (Exception ex)
            {
                return View("AddCourse", course);
            }

            // পরে এখানে Database-এ Save করবেন
            // _context.Courses.Add(course);
            // _context.SaveChanges();

            return RedirectToAction("Index");
        }
         
    }
}