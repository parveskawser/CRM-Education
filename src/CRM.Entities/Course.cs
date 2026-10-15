using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsFree { get; set; } = false;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; } = 0.00m;

        public int InstructorId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(InstructorId))]
        public virtual InstructorProfile Instructor { get; set; } = null!;

        public virtual ICollection<CourseOutline> Outlines { get; set; } = new List<CourseOutline>();
        public virtual ICollection<Module> Modules { get; set; } = new List<Module>();
        public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();
        public virtual ICollection<CourseReview> Reviews { get; set; } = new List<CourseReview>();
        public virtual ICollection<AiCourseQuery> AiQueries { get; set; } = new List<AiCourseQuery>();
    }
}
