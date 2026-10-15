using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class AssignmentSubmission
    {
        [Key]
        public int SubmissionId { get; set; }

        public int AssignmentId { get; set; }
        public int StudentId { get; set; }

        [StringLength(500)]
        public string SubmissionFileUrl { get; set; } = string.Empty;

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        public int? ObtainedMarks { get; set; }
        public string? InstructorFeedback { get; set; }

        [ForeignKey(nameof(AssignmentId))]
        public virtual Assignment Assignment { get; set; } = null!;

        [ForeignKey(nameof(StudentId))]
        public virtual StudentProfile Student { get; set; } = null!;
    }
}
