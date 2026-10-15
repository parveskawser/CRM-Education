using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }

        public int OutlineId { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        public int DurationMinutes { get; set; }
        public int TotalMarks { get; set; }

        [ForeignKey(nameof(OutlineId))]
        public virtual CourseOutline Outline { get; set; } = null!;

        public virtual ICollection<QuizQuestion> Questions { get; set; } = new List<QuizQuestion>();
        public virtual ICollection<QuizAttempt> Attempts { get; set; } = new List<QuizAttempt>();
    }
}
