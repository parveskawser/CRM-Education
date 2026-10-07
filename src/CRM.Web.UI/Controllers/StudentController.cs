using CRM.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index(int page = 0)
        {
            int pageno = (page <= 0) ? 1 : page;

            ViewBag.pageno = pageno;

            var students = Students;

            return View(students);
        }

        public IActionResult Detail(int id)
        {
            var student = Students.FirstOrDefault(x => x.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        #region datafeeder

        private static readonly List<Student> Students = new()
        {
            new Student
            {
                Id = 1,
                FullName = "Abeer Rahman",
                Email = "abeer@example.com",
                Phone = "01710000001",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 5, 15),
                Address = "Dhaka, Bangladesh",
                CourseId = 1,
                BatchId = 1,
                EnrollmentDate = new DateTime(2026, 1, 10),
                Status = "Active"
            },

            new Student
            {
                Id = 2,
                FullName = "Nusrat Jahan",
                Email = "nusrat@example.com",
                Phone = "01710000002",
                Gender = "Female",
                DateOfBirth = new DateTime(2001, 8, 22),
                Address = "Chittagong, Bangladesh",
                CourseId = 2,
                BatchId = 1,
                EnrollmentDate = new DateTime(2026, 1, 15),
                Status = "Active"
            },

            new Student
            {
                Id = 3,
                FullName = "Tanvir Hasan",
                Email = "tanvir@example.com",
                Phone = "01710000003",
                Gender = "Male",
                DateOfBirth = new DateTime(2003, 2, 10),
                Address = "Sylhet, Bangladesh",
                CourseId = 1,
                BatchId = 2,
                EnrollmentDate = new DateTime(2026, 2, 5),
                Status = "Active"
            },

            new Student
            {
                Id = 4,
                FullName = "Sadia Akter",
                Email = "sadia@example.com",
                Phone = "01710000004",
                Gender = "Female",
                DateOfBirth = new DateTime(2002, 11, 5),
                Address = "Rajshahi, Bangladesh",
                CourseId = 3,
                BatchId = 2,
                EnrollmentDate = new DateTime(2026, 2, 12),
                Status = "Active"
            },

            new Student
            {
                Id = 5,
                FullName = "Fahim Ahmed",
                Email = "fahim@example.com",
                Phone = "01710000005",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 7, 18),
                Address = "Khulna, Bangladesh",
                CourseId = 4,
                BatchId = 3,
                EnrollmentDate = new DateTime(2026, 3, 1),
                Status = "Inactive"
            }
        };

        #endregion
    }
}