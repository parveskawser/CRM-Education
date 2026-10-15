using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        public int OutlineId { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        public string Instructions { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public int TotalMarks { get; set; } = 100;

        [ForeignKey(nameof(OutlineId))]
        public virtual CourseOutline Outline { get; set; } = null!;

        public virtual ICollection<AssignmentSubmission> Submissions { get; set; } = new List<AssignmentSubmission>();
    }
}
