using CRM.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class AttendancesController : Controller
    {
        public IActionResult Index()
        {
            var attendances = Attendances;

            return View(attendances);
        }

        public IActionResult Detail(int id)
        {
            var attendance = Attendances.FirstOrDefault(x => x.Id == id);

            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }



        #region DataFeeder

        private static readonly List<Attendance> Attendances = new()
        {
            new Attendance
            {
                Id = 1,
                StudentId = 101,
                CourseId = 1,
                AttendanceDate = new DateTime(2026, 10, 1),
                IsPresent = true,
                Remarks = "Attended full class"
            },

            new Attendance
            {
                Id = 2,
                StudentId = 102,
                CourseId = 1,
                AttendanceDate = new DateTime(2026, 10, 1),
                IsPresent = true,
                Remarks = "Attended full class"
            },

            new Attendance
            {
                Id = 3,
                StudentId = 103,
                CourseId = 1,
                AttendanceDate = new DateTime(2026, 10, 1),
                IsPresent = false,
                Remarks = "Absent"
            },

            new Attendance
            {
                Id = 4,
                StudentId = 101,
                CourseId = 2,
                AttendanceDate = new DateTime(2026, 10, 2),
                IsPresent = true,
                Remarks = "Present"
            },

            new Attendance
            {
                Id = 5,
                StudentId = 102,
                CourseId = 2,
                AttendanceDate = new DateTime(2026, 10, 2),
                IsPresent = false,
                Remarks = "Not attended"
            },

            new Attendance
            {
                Id = 6,
                StudentId = 103,
                CourseId = 2,
                AttendanceDate = new DateTime(2026, 10, 2),
                IsPresent = true,
                Remarks = "Present"
            }
        };

        #endregion
    }

     
}

