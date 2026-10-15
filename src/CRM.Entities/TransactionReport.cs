using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class TransactionReport
    {
        [Key]
        public int ReportId { get; set; }

        public int AccountId { get; set; }
        public int? PaymentId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Required, StringLength(20)]
        public string TransactionType { get; set; } = "Credit";

        [StringLength(250)]
        public string Description { get; set; } = string.Empty;

        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; } = null!;

        [ForeignKey(nameof(PaymentId))]
        public virtual Payment? Payment { get; set; }
    }
}
