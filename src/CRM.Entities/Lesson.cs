using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }

        public int? ModuleId { get; set; }
        public int? OutlineId { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [StringLength(500)]
        public string? VideoUrl { get; set; }

        public string? Content { get; set; }

        public bool IsDemoLecture { get; set; } = false;

        public int DisplayOrder { get; set; } = 1;

        [ForeignKey(nameof(ModuleId))]
        public virtual Module? Module { get; set; }

        [ForeignKey(nameof(OutlineId))]
        public virtual CourseOutline? Outline { get; set; }

        public virtual ICollection<LessonProgress> ProgressRecords { get; set; } = new List<LessonProgress>();
    }

}
