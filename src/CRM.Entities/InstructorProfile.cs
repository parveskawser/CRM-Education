using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class InstructorProfile
    {
        [Key, ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [StringLength(500)]
        public string? Bio { get; set; }

        [StringLength(200)]
        public string? Expertise { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CommissionPercentage { get; set; } = 80.00m;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
        public virtual ICollection<LiveClass> LiveClasses { get; set; } = new List<LiveClass>();
    }
}
