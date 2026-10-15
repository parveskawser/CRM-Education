using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class Account
    {
        [Key, ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; } = 0.00m;

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<TransactionReport> Transactions { get; set; } = new List<TransactionReport>();
    }
}
