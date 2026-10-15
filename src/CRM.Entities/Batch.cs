using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class Batch
    {
        [Key]
        public int BatchId { get; set; }

        public int CourseId { get; set; }

        [Required, StringLength(100)]
        public string BatchName { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxCapacity { get; set; } = 50;

        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; } = null!;

        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public virtual ICollection<LiveClass> LiveClasses { get; set; } = new List<LiveClass>();
    }

}
