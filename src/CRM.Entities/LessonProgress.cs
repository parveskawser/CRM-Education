using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class LessonProgress
    {
        [Key]
        public int ProgressId { get; set; }

        public int EnrollmentId { get; set; }
        public int LessonId { get; set; }

        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedAt { get; set; }

        [ForeignKey(nameof(EnrollmentId))]
        public virtual Enrollment Enrollment { get; set; } = null!;

        [ForeignKey(nameof(LessonId))]
        public virtual Lesson Lesson { get; set; } = null!;
    }
}
