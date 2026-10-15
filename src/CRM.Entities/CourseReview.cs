using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class CourseReview
    {
        [Key]
        public int ReviewId { get; set; }

        public int CourseId { get; set; }
        public int StudentId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; } = null!;

        [ForeignKey(nameof(StudentId))]
        public virtual StudentProfile Student { get; set; } = null!;
    }
}
