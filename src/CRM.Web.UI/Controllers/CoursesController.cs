
using CRM.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index(int page = 0)
        {
            int pageno = 0;

            //if(page <= pageno)
            //    pageno = 1; 
            //else
            //    pageno = page;

            pageno = (page <= pageno) ? 1 : page;
           

            ViewBag.pageno = pageno;

            //Model

            //List<Course> listCourse = new List<Course>();
            //listCourse.Add(new Course()
            //{
            //    Title="Bangla"
            //});
            //listCourse.Add(new Course()
            //{
            //    Title = "English"
            //});
            var courses = Courses; 

            return View(courses);
        }

        public IActionResult Detail(int id)
        {
            var course = Courses.FirstOrDefault(x => x.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
         
        public IActionResult StudentCourse()
        {

            StudentCourse course = new StudentCourse();
            course.CourseList = Courses;
            course.Student = Student;

            return View(course);
        }

        #region datafeeder
        private static readonly Students Student = new Students
        {
            Id = 2,
            Name = "Marufa",
            Age = 22,
            Department = "CSE",
            Email = "marufa@gmail.com"
        };
        private static readonly List<Course> Courses = new()
        {
        new Course
        {
            Id = 1,
            Title = "Full Stack ASP.NET Core MVC",
            ShortDescription = "Build modern web applications using ASP.NET Core.",
            Description = "This course covers C#, ASP.NET Core MVC, Entity Framework Core, SQL Server, authentication, admin panel, and deployment.",
            Price = 5000,
            DiscountPrice = 3500,
            InstructorId = 1,
            CategoryId = 1,
            Level = "Beginner",
            Language = "Bangla",
            TotalLessons = 40,
            DurationInMinutes = 720,
            IsPublished = true,
            IsFeatured = true
        },new Course
                {
                    Id = 2,
                    Title = "C# Programming Fundamentals",
                    ShortDescription = "Learn C# from basic to object-oriented programming.",
                    Price = 3000,
                    InstructorId = 1,
                    CategoryId = 1,
                    Level = "Beginner",
                    Language = "Bangla",
                    TotalLessons = 30,
                    DurationInMinutes = 540,
                    IsPublished = true
                },
                new Course
                {
                    Id = 3,
                    Title = "SQL Server Database Design",
                    ShortDescription = "Database design, queries, joins, and stored procedures.",
                    Price = 3500,
                    DiscountPrice = 2500,
                    InstructorId = 2,
                    CategoryId = 2,
                    Level = "Intermediate",
                    Language = "Bangla",
                    TotalLessons = 35,
                    DurationInMinutes = 600,
                    IsPublished = true
                },
                new Course
                {
                    Id = 4,
                    Title = "Flutter Mobile App Development",
                    ShortDescription = "Create Android and iOS applications with Flutter.",
                    Price = 6000,
                    InstructorId = 3,
                    CategoryId = 3,
                    Level = "Beginner",
                    Language = "Bangla",
                    TotalLessons = 50,
                    DurationInMinutes = 900,
                    IsPublished = true,
                    IsFeatured = true
                },
                new Course
                {
                    Id = 5,
                    Title = "React JS for Beginners",
                    ShortDescription = "Build interactive frontend applications with React.",
                    Price = 4000,
                    DiscountPrice = 2999,
                    InstructorId = 4,
                    CategoryId = 4,
                    Level = "Beginner",
                    Language = "English",
                    TotalLessons = 32,
                    DurationInMinutes = 580,
                    IsPublished = true
                },
                new Course
                {
                    Id = 6,
                    Title = "Digital Marketing Masterclass",
                    ShortDescription = "Learn Meta Ads, Google Ads, and social media marketing.",
                    Price = 4500,
                    InstructorId = 5,
                    CategoryId = 5,
                    Level = "Beginner",
                    Language = "Bangla",
                    TotalLessons = 36,
                    DurationInMinutes = 650,
                    IsPublished = true
                },
                new Course
                {
                    Id = 7,
                    Title = "Advanced ASP.NET Core Web API",
                    ShortDescription = "Create secure REST APIs with JWT authentication.",
                    Price = 5500,
                    InstructorId = 1,
                    CategoryId = 1,
                    Level = "Advanced",
                    Language = "English",
                    TotalLessons = 45,
                    DurationInMinutes = 800,
                    IsPublished = true
                },
                new Course
                {
                    Id = 8,
                    Title = "UI UX Design with Figma",
                    ShortDescription = "Design web and mobile interfaces using Figma.",
                    Price = 4000,
                    DiscountPrice = 2800,
                    InstructorId = 6,
                    CategoryId = 6,
                    Level = "Beginner",
                    Language = "Bangla",
                    TotalLessons = 28,
                    DurationInMinutes = 480,
                    IsPublished = true
                },
                new Course
                {
                    Id = 9,
                    Title = "Software Quality Assurance",
                    ShortDescription = "Manual testing, test cases, bug reporting, and QA process.",
                    Price = 3500,
                    InstructorId = 7,
                    CategoryId = 7,
                    Level = "Beginner",
                    Language = "Bangla",
                    TotalLessons = 30,
                    DurationInMinutes = 520,
                    IsPublished = false
                },
                new Course
                {
                    Id = 10,
                    Title = "E-Commerce Business Management",
                    ShortDescription = "Learn product, order, inventory, payment, and courier management.",
                    Price = 3000,
                    DiscountPrice = 1999,
                    InstructorId = 8,
                    CategoryId = 8,
                    Level = "Intermediate",
                    Language = "Bangla",
                    TotalLessons = 25,
                    DurationInMinutes = 420,
                    IsPublished = true,
                    IsFeatured = true
                }

        // Add your other 9 course records here
    };

        #endregion
    }
}
