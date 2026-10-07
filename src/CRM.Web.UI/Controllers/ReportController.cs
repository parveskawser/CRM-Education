using CRM.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CRM.Web.UI.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index(int page = 0)
        {
            int pageno = 0;

            // pageno = (page <= pageno) ? 1 : page;
            pageno = (page <= pageno) ? 1 : page;

            ViewBag.pageno = pageno;

            var reports = Reports;

            return View(reports);
        }

        public IActionResult Detail(int id)
        {
            var report = Reports.FirstOrDefault(x => x.Id == id);

            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        #region datafeeder

        private static readonly List<ReportDefinition> Reports = new()
        {
            new ReportDefinition
            {
                Id = 1,
                Name = "Course Enrollment Summary",
                Code = "RPT-ENROLL-01",
                Summary = "Summary of student course enrollments per month.",
                Description = "This report displays total enrollments, revenue breakdown by category, active student participation, and monthly enrollment trends."
            },
            new ReportDefinition
            {
                Id = 2,
                Name = "Monthly Revenue Report",
                Code = "RPT-REV-02",
                Summary = "Detailed financial report of course sales.",
                Description = "Tracks gross revenue, discount subtractions, net profit, and payment channel distributions across all active courses."
            },
            new ReportDefinition
            {
                Id = 3,
                Name = "Instructor Performance Metrics",
                Code = "RPT-INST-03",
                Summary = "Overview of instructor active courses and ratings.",
                Description = "Provides detailed insights on instructor performance including student completion rates, average reviews, and published course count."
            },
            new ReportDefinition
            {
                Id = 4,
                Name = "Student Completion Rate",
                Code = "RPT-COMP-04",
                Summary = "Tracks course completion percentages for students.",
                Description = "Generates metrics showing how far students progress through assigned course lessons and final assessment completions."
            },
            new ReportDefinition
            {
                Id = 5,
                Name = "Course Ratings and Reviews",
                Code = "RPT-REVW-05",
                Summary = "Summary of student feedback and rating metrics.",
                Description = "Lists all course reviews, customer satisfaction scores, average ratings, and highlighted qualitative student feedback."
            },
            new ReportDefinition
            {
                Id = 6,
                Name = "Discount & Promo Usage Report",
                Code = "RPT-DISC-06",
                Summary = "Analysis of discount code performance.",
                Description = "Analyzes how coupon codes impact sales revenue, customer conversion rates, and total promotional discounts claimed."
            },
            new ReportDefinition
            {
                Id = 7,
                Name = "Top Featured Courses Analysis",
                Code = "RPT-FEAT-07",
                Summary = "Performance metrics for featured vs non-featured courses.",
                Description = "Compares traffic, conversion rates, and enrollment totals between featured spotlight courses and standard catalog items."
            },
            new ReportDefinition
            {
                Id = 8,
                Name = "Category-wise Sales Breakdown",
                Code = "RPT-CAT-08",
                Summary = "Report on total revenue grouped by course category.",
                Description = "Breaks down course performance by category such as Web Development, Design, QA, and Digital Marketing to identify top performers."
            },
            new ReportDefinition
            {
                Id = 9,
                Name = "Unpublished & Draft Courses",
                Code = "RPT-DRAFT-09",
                Summary = "Audit report for pending or draft course materials.",
                Description = "Lists courses currently in draft status, pending instructor uploads, or awaiting administrative review prior to publication."
            },
            new ReportDefinition
            {
                Id = 10,
                Name = "Active vs Inactive Students",
                Code = "RPT-ACTV-10",
                Summary = "User activity report categorizing active vs idle students.",
                Description = "Identifies dormant user accounts vs active learners to assist marketing teams in executing re-engagement email campaigns."
            }
        };

        #endregion
    }
}