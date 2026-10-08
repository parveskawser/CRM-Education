using CRM.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class BatchesController : Controller
    {
        public IActionResult Index(int page = 0)
        {
            int pageno = 0;

            pageno = (page <= pageno) ? 1 : page;

            ViewBag.pageno = pageno;

            var batches = Batches;

            return View(batches);
        }


        public IActionResult Detail(int id)
        {
            var batch = Batches.FirstOrDefault(x => x.Id == id);

            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }


        public IActionResult BatchCourse()
        {
            CRM.Entities.Batches model = new CRM.Entities.Batches();

            model.BatchList = Batches;
            model.CourseList = Courses;

            return View(model);
        }


        #region datafeeder

        private static readonly List<Batch> Batches = new()
        {
            new Batch
            {
                Id = 1,
                BatchName = "ASP.NET · Batch 12",
                CourseId = 1,
                Schedule = "Mon, Wed · 9:00 PM",
                Capacity = 40,
                StartDate = new DateTime(2026, 10, 15),
                EndDate = new DateTime(2027, 01, 15),
                Status = "Active",
                IsActive = true
            },

            new Batch
            {
                Id = 2,
                BatchName = "ASP.NET · Batch 13",
                CourseId = 1,
                Schedule = "Tue, Thu · 7:00 PM",
                Capacity = 35,
                StartDate = new DateTime(2026, 11, 01),
                EndDate = new DateTime(2027, 02, 01),
                Status = "Active",
                IsActive = true
            },

            new Batch
            {
                Id = 3,
                BatchName = "ASP.NET · Batch 14",
                CourseId = 1,
                Schedule = "Fri, Sat · 8:00 PM",
                Capacity = 40,
                StartDate = new DateTime(2026, 11, 20),
                EndDate = new DateTime(2027, 02, 20),
                Status = "Scheduled",
                IsActive = false
            },

            new Batch
            {
                Id = 4,
                BatchName = "C# · Batch 08",
                CourseId = 2,
                Schedule = "Sun, Tue · 8:00 PM",
                Capacity = 30,
                StartDate = new DateTime(2026, 10, 20),
                EndDate = new DateTime(2026, 12, 20),
                Status = "Active",
                IsActive = true
            },

            new Batch
            {
                Id = 5,
                BatchName = "SQL Server · Batch 05",
                CourseId = 3,
                Schedule = "Mon, Thu · 7:30 PM",
                Capacity = 30,
                StartDate = new DateTime(2026, 11, 05),
                EndDate = new DateTime(2027, 01, 10),
                Status = "Scheduled",
                IsActive = false
            },

            new Batch
            {
                Id = 6,
                BatchName = "Flutter · Batch 06",
                CourseId = 4,
                Schedule = "Fri, Sat · 6:00 PM",
                Capacity = 35,
                StartDate = new DateTime(2026, 10, 25),
                EndDate = new DateTime(2027, 02, 25),
                Status = "Active",
                IsActive = true
            },

            new Batch
            {
                Id = 7,
                BatchName = "React JS · Batch 04",
                CourseId = 5,
                Schedule = "Sun, Tue · 9:00 PM",
                Capacity = 30,
                StartDate = new DateTime(2026, 11, 10),
                EndDate = new DateTime(2027, 01, 30),
                Status = "Scheduled",
                IsActive = false
            },

            new Batch
            {
                Id = 8,
                BatchName = "Digital Marketing · Batch 05",
                CourseId = 6,
                Schedule = "Fri, Sat · 8:00 PM",
                Capacity = 35,
                StartDate = new DateTime(2026, 10, 30),
                EndDate = new DateTime(2027, 01, 15),
                Status = "Active",
                IsActive = true
            },

            new Batch
            {
                Id = 9,
                BatchName = "ASP.NET Web API · Batch 03",
                CourseId = 7,
                Schedule = "Mon, Wed · 8:00 PM",
                Capacity = 25,
                StartDate = new DateTime(2026, 12, 01),
                EndDate = new DateTime(2027, 02, 28),
                Status = "Scheduled",
                IsActive = false
            },

            new Batch
            {
                Id = 10,
                BatchName = "UI/UX Design · Batch 08",
                CourseId = 8,
                Schedule = "Tue, Thu · 7:00 PM",
                Capacity = 30,
                StartDate = new DateTime(2026, 10, 18),
                EndDate = new DateTime(2026, 12, 18),
                Status = "Active",
                IsActive = true
            },

            new Batch
            {
                Id = 11,
                BatchName = "Software QA · Batch 03",
                CourseId = 9,
                Schedule = "Sun, Tue · 6:30 PM",
                Capacity = 25,
                StartDate = new DateTime(2026, 09, 15),
                EndDate = new DateTime(2026, 11, 15),
                Status = "Completed",
                IsActive = false
            },

            new Batch
            {
                Id = 12,
                BatchName = "E-Commerce · Batch 02",
                CourseId = 10,
                Schedule = "Fri, Sat · 7:00 PM",
                Capacity = 30,
                StartDate = new DateTime(2026, 12, 10),
                EndDate = new DateTime(2027, 02, 10),
                Status = "Scheduled",
                IsActive = false
            }
        };


        // IMPORTANT:
        // Your BatchCourse() action requires a Courses list.
        // Add your existing Course data here or expose it from a shared data source.

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
            },

            new Course
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
        };

        #endregion
    }
}