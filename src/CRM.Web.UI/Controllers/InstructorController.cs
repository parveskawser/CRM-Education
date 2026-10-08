using CRM.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class InstructorController : Controller
    {
        public IActionResult Index(int page = 0)
        {
            int pageno = 0;

            pageno = (page <= pageno) ? 1 : page;

            ViewBag.pageno = pageno;

            var instructors = Instructors;

            return View(instructors);
        }


        public IActionResult Detail(int id)
        {
            var instructor = Instructors.FirstOrDefault(x => x.Id == id);

            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }


        public IActionResult InstructorCourse(int id)
        {
            var instructorData = Instructors.FirstOrDefault(x => x.Id == id);

            if (instructorData == null)
            {
                return NotFound();
            }

            InstructorCourse instructor = new InstructorCourse();

            instructor.Instructor = instructorData;

            instructor.CourseList = Courses
                .Where(x => x.InstructorId == id)
                .ToList();

            return View(instructor);
        }


        #region datafeeder

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


        private static readonly List<Instructor> Instructors = new()
        {
            new Instructor
            {
                Id = 1,
                Name = "Md. Rahim Ahmed",
                Email = "rahim@example.com",
                Phone = "01711111111",

                Bio = "Experienced software developer and ASP.NET Core instructor.",
                Expertise = "C#, ASP.NET Core, MVC, Web API",
                Qualification = "BSc in Computer Science and Engineering",
                ExperienceYears = 8,
                IsActive = true
            },

            new Instructor
            {
                Id = 2,
                Name = "Nusrat Jahan",
                Email = "nusrat@example.com",
                Phone = "01722222222",

                Bio = "Database specialist with experience in SQL Server and database design.",
                Expertise = "SQL Server, Database Design, SQL",
                Qualification = "MSc in Computer Science",
                ExperienceYears = 6,
                IsActive = true
            },

            new Instructor
            {
                Id = 3,
                Name = "Tanvir Hasan",
                Email = "tanvir@example.com",
                Phone = "01733333333",

                Bio = "Mobile application developer and Flutter instructor.",
                Expertise = "Flutter, Dart, Android, iOS",
                Qualification = "BSc in Software Engineering",
                ExperienceYears = 5,
                IsActive = true
            },

            new Instructor
            {
                Id = 4,
                Name = "Sadia Rahman",
                Email = "sadia@example.com",
                Phone = "01744444444",

                Bio = "Frontend developer specializing in modern JavaScript frameworks.",
                Expertise = "React JS, JavaScript, HTML, CSS",
                Qualification = "BSc in Computer Science",
                ExperienceYears = 5,
                IsActive = true
            },

            new Instructor
            {
                Id = 5,
                Name = "Arif Hossain",
                Email = "arif@example.com",
                Phone = "01755555555",

                Bio = "Digital marketing professional with experience in online advertising.",
                Expertise = "Digital Marketing, Meta Ads, Google Ads",
                Qualification = "MBA in Marketing",
                ExperienceYears = 7,
                IsActive = true
            },

            new Instructor
            {
                Id = 6,
                Name = "Mahi Islam",
                Email = "mahi@example.com",
                Phone = "01766666666",

                Bio = "UI/UX designer focused on creating modern and user-friendly interfaces.",
                Expertise = "UI/UX Design, Figma, Prototyping",
                Qualification = "BSc in Multimedia Design",
                ExperienceYears = 4,
                IsActive = true
            },

            new Instructor
            {
                Id = 7,
                Name = "Fahim Chowdhury",
                Email = "fahim@example.com",
                Phone = "01777777777",

                Bio = "Software quality assurance engineer and testing instructor.",
                Expertise = "Manual Testing, Automation Testing, QA",
                Qualification = "BSc in Computer Science",
                ExperienceYears = 6,
                IsActive = true
            },

            new Instructor
            {
                Id = 8,
                Name = "Imran Kabir",
                Email = "imran@example.com",
                Phone = "01788888888",

                Bio = "E-commerce specialist with experience in online business management.",
                Expertise = "E-Commerce, Inventory, Order Management",
                Qualification = "BBA in Management",
                ExperienceYears = 7,
                IsActive = true
            }
        };

        #endregion
    }
}