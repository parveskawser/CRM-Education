using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class AiCourseQuery
    {
        [Key]
        public int QueryId { get; set; }

        public int CourseId { get; set; }
        public int StudentId { get; set; }

        [Required]
        public string StudentQuestion { get; set; } = string.Empty;

        public string AiResponse { get; set; } = string.Empty;

        public DateTime AskedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; } = null!;

        [ForeignKey(nameof(StudentId))]
        public virtual StudentProfile Student { get; set; } = null!;
    }
}


