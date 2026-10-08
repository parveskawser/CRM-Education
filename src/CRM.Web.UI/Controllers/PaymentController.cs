using System.Collections.Generic;
using CRM.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index(int page = 0)
        {
            int pageno = 0;

            pageno = (page <= pageno) ? 1 : page;

            ViewBag.pageno = pageno;

            var payments = Payments;

            return View(payments);
        }

        public IActionResult Detail(int id)
        {
            var payment = Payments.FirstOrDefault(x => x.Id == id);

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }
       
        public IActionResult StudentPayment()
        {

            StudentPayment payment = new StudentPayment();
            // assign the existing Payments list (or filter by student if intended)
            payment.PaymentList = Payments;
            payment.Student = Student;

            return View(payment);
        }

        private static readonly Students Student = new Students
        {
            Id = 2,
            Name = "Marufa",
            Age = 22,
            Department = "CSE",
            Email = "marufa@gmail.com"
        };

        #region datafeeder

        private static readonly List<Payment> Payments = new()
        {
            new Payment
            {
                Id = 1,
                StudentId = 101,
                CourseId = 1,
                Amount = 3500,
                DiscountAmount = 1500,
                PaymentMethod = "bKash",
                TransactionId = "BKASH10001",
                PaymentDate = new DateTime(2026, 10, 1),
                Status = "Completed",
                Remarks = "Course enrollment payment",
                IsSuccessful = true
            },

            new Payment
            {
                Id = 2,
                StudentId = 102,
                CourseId = 2,
                Amount = 3000,
                PaymentMethod = "Cash",
                TransactionId = "CASH10002",
                PaymentDate = new DateTime(2026, 10, 2),
                Status = "Completed",
                Remarks = "Paid at office",
                IsSuccessful = true
            },

            new Payment
            {
                Id = 3,
                StudentId = 103,
                CourseId = 3,
                Amount = 2500,
                DiscountAmount = 1000,
                PaymentMethod = "Nagad",
                TransactionId = "NAGAD10003",
                PaymentDate = new DateTime(2026, 10, 3),
                Status = "Completed",
                Remarks = "Discount applied",
                IsSuccessful = true
            },

            new Payment
            {
                Id = 4,
                StudentId = 104,
                CourseId = 4,
                Amount = 6000,
                PaymentMethod = "Card",
                TransactionId = "CARD10004",
                PaymentDate = new DateTime(2026, 10, 4),
                Status = "Pending",
                Remarks = "Payment verification pending",
                IsSuccessful = false
            },

            new Payment
            {
                Id = 5,
                StudentId = 105,
                CourseId = 5,
                Amount = 2999,
                DiscountAmount = 1001,
                PaymentMethod = "bKash",
                TransactionId = "BKASH10005",
                PaymentDate = new DateTime(2026, 10, 5),
                Status = "Completed",
                Remarks = "Full payment received",
                IsSuccessful = true
            },

            new Payment
            {
                Id = 6,
                StudentId = 106,
                CourseId = 6,
                Amount = 4500,
                PaymentMethod = "Bank",
                TransactionId = "BANK10006",
                PaymentDate = new DateTime(2026, 10, 6),
                Status = "Failed",
                Remarks = "Bank transaction failed",
                IsSuccessful = false
            },

            new Payment
            {
                Id = 7,
                StudentId = 107,
                CourseId = 7,
                Amount = 5500,
                PaymentMethod = "Card",
                TransactionId = "CARD10007",
                PaymentDate = new DateTime(2026, 10, 7),
                Status = "Completed",
                Remarks = "Online payment",
                IsSuccessful = true
            },

            new Payment
            {
                Id = 8,
                StudentId = 108,
                CourseId = 8,
                Amount = 2800,
                DiscountAmount = 1200,
                PaymentMethod = "bKash",
                TransactionId = "BKASH10008",
                PaymentDate = new DateTime(2026, 10, 7),
                Status = "Completed",
                Remarks = "Discounted course payment",
                IsSuccessful = true
            },

            new Payment
            {
                Id = 9,
                StudentId = 109,
                CourseId = 9,
                Amount = 3500,
                PaymentMethod = "Cash",
                TransactionId = "CASH10009",
                PaymentDate = new DateTime(2026, 10, 7),
                Status = "Pending",
                Remarks = "Payment confirmation pending",
                IsSuccessful = false
            },

            new Payment
            {
                Id = 10,
                StudentId = 110,
                CourseId = 10,
                Amount = 1999,
                DiscountAmount = 1001,
                PaymentMethod = "Nagad",
                TransactionId = "NAGAD10010",
                PaymentDate = new DateTime(2026, 10, 7),
                Status = "Completed",
                Remarks = "Course payment completed",
                IsSuccessful = true
            }
        };

        #endregion
    }
}