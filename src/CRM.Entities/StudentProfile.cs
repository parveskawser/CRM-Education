using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
    public class StudentProfile
    {
        [Key, ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [StringLength(100)]
        public string? EmergencyContact { get; set; }

        [StringLength(250)]
        public string? EducationalBackground { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public virtual ICollection<AssignmentSubmission> Submissions { get; set; } = new List<AssignmentSubmission>();
        public virtual ICollection<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();
        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public virtual ICollection<CourseReview> CourseReviews { get; set; } = new List<CourseReview>();
        public virtual ICollection<AiCourseQuery> AiCourseQueries { get; set; } = new List<AiCourseQuery>();
    }
}
