using CRM.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            List<Students> students = new List<Students>
            {
                new Students
                {
                    Id = 1,
                    Name = "Tasmim",
                    Age = 23,
                    Department = "CSE",
                    Email = "tasmim@gmail.com"
                },

                new Students
                {
                    Id = 2,
                    Name = "Marufa",
                    Age = 22,
                    Department = "CSE",
                    Email = "marufa@gmail.com"
                },

                new Students
                {
                    Id = 3,
                    Name = "Nusrat",
                    Age = 24,
                    Department = "BBA",
                    Email = "nusrat@gmail.com"
                }
            };

            return View(students);
        }
        public IActionResult StudentAttendance()
        {
            List<StudentAttendance> studentAttendances = new List<StudentAttendance>
    {
        new StudentAttendance
        {
            StudentId = 1,
            StudentName = "Tasmim",
            Department = "CSE",
            AttendanceDate = new DateTime(2026, 10, 1),
            IsPresent = true,
            Remarks = "Attended full class"
        },

        new StudentAttendance
        {
            StudentId = 2,
            StudentName = "Marufa",
            Department = "CSE",
            AttendanceDate = new DateTime(2026, 10, 1),
            IsPresent = true,
            Remarks = "Attended full class"
        },

        new StudentAttendance
        {
            StudentId = 3,
            StudentName = "Nusrat",
            Department = "BBA",
            AttendanceDate = new DateTime(2026, 10, 1),
            IsPresent = false,
            Remarks = "Absent"
        },

        new StudentAttendance
        {
            StudentId = 1,
            StudentName = "Tasmim",
            Department = "CSE",
            AttendanceDate = new DateTime(2026, 10, 2),
            IsPresent = true,
            Remarks = "Present"
        },

        new StudentAttendance
        {
            StudentId = 2,
            StudentName = "Marufa",
            Department = "CSE",
            AttendanceDate = new DateTime(2026, 10, 2),
            IsPresent = false,
            Remarks = "Not attended"
        },

        new StudentAttendance
        {
            StudentId = 3,
            StudentName = "Nusrat",
            Department = "BBA",
            AttendanceDate = new DateTime(2026, 10, 2),
            IsPresent = true,
            Remarks = "Present"
        }
    };

            return View(studentAttendances);
        }
        
        public IActionResult Details(int id)
        {
            List<Students> students = new List<Students>
            {
                new Students
                {
                    Id = 1,
                    Name = "Tasmim",
                    Age = 23,
                    Department = "CSE",
                    Email = "tasmim@gmail.com"
                },

                new Students
                {
                    Id = 2,
                    Name = "Marufa",
                    Age = 22,
                    Department = "CSE",
                    Email = "marufa@gmail.com"
                },

                new Students
                {
                    Id = 3,
                    Name = "Nusrat",
                    Age = 24,
                    Department = "BBA",
                    Email = "nusrat@gmail.com"
                }
            };

            Students student = students.FirstOrDefault(s => s.Id == id);

            return View(student);
        }
    }
}
