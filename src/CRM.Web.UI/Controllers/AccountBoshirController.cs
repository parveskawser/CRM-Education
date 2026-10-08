using CRM.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class AccountBoshirController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StudentCourse()
        {
            StudentCourse model = new StudentCourse();
            model.Student = Student;
            model.CourseList = Courses;

            return View(model);
        }

        private static readonly Students Student = new Students
        {
            Id = 2,
            Name = "Boshir",
            Age = 22,
            Department = "CSE",
            Email = "boshir@gmail.com"
        };

        private static readonly List<Course> Courses = new()
        {
            new Course { Id = 1, Title = "Full Stack ASP.NET Core MVC", Level = "Beginner" },
            new Course { Id = 2, Title = "C# Programming Fundamentals", Level = "Beginner" },
            new Course { Id = 3, Title = "SQL Server Database Design", Level = "Intermediate" }
        };
    }
}