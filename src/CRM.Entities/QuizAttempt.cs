using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class QuizAttempt
    {
        [Key]
        public int AttemptId { get; set; }

        public int QuizId { get; set; }
        public int StudentId { get; set; }

        public int ScoreObtained { get; set; }
        public DateTime AttemptedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(QuizId))]
        public virtual Quiz Quiz { get; set; } = null!;

        [ForeignKey(nameof(StudentId))]
        public virtual StudentProfile Student { get; set; } = null!;
    }
}
