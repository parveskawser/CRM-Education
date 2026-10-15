using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class QuizQuestion
    {
        [Key]
        public int QuestionId { get; set; }

        public int QuizId { get; set; }

        [Required]
        public string QuestionText { get; set; } = string.Empty;

        [Required]
        public string OptionA { get; set; } = string.Empty;

        [Required]
        public string OptionB { get; set; } = string.Empty;

        public string? OptionC { get; set; }
        public string? OptionD { get; set; }

        [Required, StringLength(1)]
        public string CorrectOption { get; set; } = string.Empty;

        public int Marks { get; set; } = 1;

        [ForeignKey(nameof(QuizId))]
        public virtual Quiz Quiz { get; set; } = null!;
    }
}
