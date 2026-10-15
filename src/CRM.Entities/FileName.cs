 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Entities
{
    // ==========================================
    // 1. ACCOUNT & USER MANAGEMENT
    // ==========================================

    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required, StringLength(50)]
        public string RoleName { get; set; } = string.Empty; // e.g., Admin, Instructor, Student

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(256)]
        public string PasswordHash { get; set; } = string.Empty;

        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        public int RoleId { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; } = null!;

        public virtual StudentProfile? StudentProfile { get; set; }
        public virtual InstructorProfile? InstructorProfile { get; set; }
        public virtual Account? Account { get; set; }
    }

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

    public class InstructorProfile
    {
        [Key, ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [StringLength(500)]
        public string? Bio { get; set; }

        [StringLength(200)]
        public string? Expertise { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CommissionPercentage { get; set; } = 80.00m;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
        public virtual ICollection<LiveClass> LiveClasses { get; set; } = new List<LiveClass>();
    }

    // ==========================================
    // 2. COURSE STRUCTURE & LESSONS
    // ==========================================

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

    public class Module
    {
        [Key]
        public int ModuleId { get; set; }

        public int CourseId { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        public int DisplayOrder { get; set; } = 1;

        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; } = null!;

        public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }

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

    // ==========================================
    // 3. BATCHES, ENROLLMENTS & PROGRESS
    // ==========================================

    public class Batch
    {
        [Key]
        public int BatchId { get; set; }

        public int CourseId { get; set; }

        [Required, StringLength(100)]
        public string BatchName { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxCapacity { get; set; } = 50;

        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; } = null!;

        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public virtual ICollection<LiveClass> LiveClasses { get; set; } = new List<LiveClass>();
    }

    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }
        public int BatchId { get; set; }

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(StudentId))]
        public virtual StudentProfile Student { get; set; } = null!;

        [ForeignKey(nameof(BatchId))]
        public virtual Batch Batch { get; set; } = null!;

        public virtual ICollection<LessonProgress> LessonProgresses { get; set; } = new List<LessonProgress>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }

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

    public class LiveClass
    {
        [Key]
        public int LiveClassId { get; set; }

        public int BatchId { get; set; }
        public int InstructorId { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        public DateTime ScheduledStartTime { get; set; }
        public DateTime ScheduledEndTime { get; set; }

        [StringLength(500)]
        public string? MeetingUrl { get; set; }

        [StringLength(500)]
        public string? RecordingUrl { get; set; }

        [ForeignKey(nameof(BatchId))]
        public virtual Batch Batch { get; set; } = null!;

        [ForeignKey(nameof(InstructorId))]
        public virtual InstructorProfile Instructor { get; set; } = null!;

        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }

    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        public int LiveClassId { get; set; }
        public int StudentId { get; set; }
        public int EnrollmentId { get; set; }

        public bool IsPresent { get; set; } = false;
        public DateTime? JoinedAt { get; set; }

        [ForeignKey(nameof(LiveClassId))]
        public virtual LiveClass LiveClass { get; set; } = null!;

        [ForeignKey(nameof(StudentId))]
        public virtual StudentProfile Student { get; set; } = null!;

        [ForeignKey(nameof(EnrollmentId))]
        public virtual Enrollment Enrollment { get; set; } = null!;
    }

    // ==========================================
    // 4. ASSIGNMENTS & QUIZZES
    // ==========================================

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

    // ==========================================
    // 5. ACCOUNTS, PAYMENTS & REVIEWS
    // ==========================================

    public class Account
    {
        [Key, ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; } = 0.00m;

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<TransactionReport> Transactions { get; set; } = new List<TransactionReport>();
    }

    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int EnrollmentId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Required, StringLength(50)]
        public string PaymentMethod { get; set; } = "CreditCard";

        [Required, StringLength(50)]
        public string PaymentStatus { get; set; } = "Completed";

        [StringLength(100)]
        public string TransactionId { get; set; } = string.Empty;

        public DateTime PaidAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(EnrollmentId))]
        public virtual Enrollment Enrollment { get; set; } = null!;

        public virtual TransactionReport? TransactionReport { get; set; }
    }

    public class TransactionReport
    {
        [Key]
        public int ReportId { get; set; }

        public int AccountId { get; set; }
        public int? PaymentId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Required, StringLength(20)]
        public string TransactionType { get; set; } = "Credit";

        [StringLength(250)]
        public string Description { get; set; } = string.Empty;

        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; } = null!;

        [ForeignKey(nameof(PaymentId))]
        public virtual Payment? Payment { get; set; }
    }

    public class CourseReview
    {
        [Key]
        public int ReviewId { get; set; }

        public int CourseId { get; set; }
        public int StudentId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; } = null!;

        [ForeignKey(nameof(StudentId))]
        public virtual StudentProfile Student { get; set; } = null!;
    }

    // ==========================================
    // 6. AI Q/A COURSE WISE
    // ==========================================

    public class AiCourseQuery
    {
        [Key]
        public int QueryId { get; set; }

        public int CourseId { get; set; }
        public int StudentId { get; set; }

        [Required]
        public string StudentQuestion { get; set; } = string.Empty;

        public string AiResponse { get; set; } = string.Empty;

        public DateTime AskedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; } = null!;

        [ForeignKey(nameof(StudentId))]
        public virtual StudentProfile Student { get; set; } = null!;
    }
}
