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


        #region datafeeder

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
