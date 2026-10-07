using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public decimal Amount { get; set; }
        public decimal? DiscountAmount { get; set; }

        public string PaymentMethod { get; set; } = "Cash";
        // Cash, Card, bKash, Nagad, Bank

        public string TransactionId { get; set; } = string.Empty;

        public DateTime PaymentDate { get; set; }

        public string Status { get; set; } = "Pending";
        // Pending, Completed, Failed, Refunded

        public string? Remarks { get; set; }

        public bool IsSuccessful { get; set; }
    }
}