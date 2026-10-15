using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int EnrollmentId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Required, StringLength(50)]
        public string PaymentMethod { get; set; } = "CreditCard";

        [Required, StringLength(50)]
        public string PaymentStatus { get; set; } = "Completed";

        [StringLength(100)]
        public string TransactionId { get; set; } = string.Empty;

        public DateTime PaidAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(EnrollmentId))]
        public virtual Enrollment Enrollment { get; set; } = null!;

        public virtual TransactionReport? TransactionReport { get; set; }
    }
}
