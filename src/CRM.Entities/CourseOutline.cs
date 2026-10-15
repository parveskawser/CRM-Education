using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class CourseOutline
    {
        [Key]
        public int OutlineId { get; set; }

        public int CourseId { get; set; }

        [Required, StringLength(200)]
        public string ModuleTitle { get; set; } = string.Empty;

        public string? Overview { get; set; }

        public int DisplayOrder { get; set; }

        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; } = null!;

        public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
        public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
        public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
    }
}
