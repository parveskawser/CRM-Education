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

        #endregion
    }
}