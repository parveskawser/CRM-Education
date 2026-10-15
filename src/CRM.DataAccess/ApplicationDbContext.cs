
using Microsoft.EntityFrameworkCore;
using CRM.Entities;

namespace CRM.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<StudentProfile> StudentProfiles { get; set; } = null!;
        public DbSet<InstructorProfile> InstructorProfiles { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<CourseOutline> CourseOutlines { get; set; } = null!;
        public DbSet<Module> Modules { get; set; } = null!;
        public DbSet<Lesson> Lessons { get; set; } = null!;
        public DbSet<LessonProgress> LessonProgresses { get; set; } = null!;
        public DbSet<Batch> Batches { get; set; } = null!;
        public DbSet<Enrollment> Enrollments { get; set; } = null!;
        public DbSet<LiveClass> LiveClasses { get; set; } = null!;
        public DbSet<Attendance> Attendances { get; set; } = null!;
        public DbSet<Assignment> Assignments { get; set; } = null!;
        public DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; } = null!;
        public DbSet<Quiz> Quizzes { get; set; } = null!;
        public DbSet<QuizQuestion> QuizQuestions { get; set; } = null!;
        public DbSet<QuizAttempt> QuizAttempts { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<TransactionReport> TransactionReports { get; set; } = null!;
        public DbSet<CourseReview> CourseReviews { get; set; } = null!;
        public DbSet<AiCourseQuery> AiCourseQueries { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Users & Profiles
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.Email).IsUnique();
                entity.HasOne(u => u.Role)
                      .WithMany(r => r.Users)
                      .HasForeignKey(u => u.RoleId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StudentProfile>(entity =>
            {
                entity.HasKey(sp => sp.UserId);
                entity.HasOne(sp => sp.User)
                      .WithOne(u => u.StudentProfile)
                      .HasForeignKey<StudentProfile>(sp => sp.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<InstructorProfile>(entity =>
            {
                entity.HasKey(ip => ip.UserId);
                entity.Property(ip => ip.CommissionPercentage).HasColumnType("decimal(18, 2)");
                entity.HasOne(ip => ip.User)
                      .WithOne(u => u.InstructorProfile)
                      .HasForeignKey<InstructorProfile>(ip => ip.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.UserId);
                entity.Property(a => a.Balance).HasColumnType("decimal(18, 2)");
                entity.HasOne(a => a.User)
                      .WithOne(u => u.Account)
                      .HasForeignKey<Account>(a => a.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // 2. Course & Modules
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(c => c.Price).HasColumnType("decimal(18, 2)");
                entity.HasOne(c => c.Instructor)
                      .WithMany(ip => ip.Courses)
                      .HasForeignKey(c => c.InstructorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasOne(m => m.Course)
                      .WithMany(c => c.Modules)
                      .HasForeignKey(m => m.CourseId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CourseOutline>(entity =>
            {
                entity.HasOne(co => co.Course)
                      .WithMany(c => c.Outlines)
                      .HasForeignKey(co => co.CourseId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.HasOne(l => l.Module)
                      .WithMany(m => m.Lessons)
                      .HasForeignKey(l => l.ModuleId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(l => l.Outline)
                      .WithMany(co => co.Lessons)
                      .HasForeignKey(l => l.OutlineId)
                      .OnDelete(DeleteBehavior.NoAction); // Prevents multiple cascade path
            });

            // 3. Batches, Enrollments & Progress
            modelBuilder.Entity<Batch>(entity =>
            {
                entity.HasOne(b => b.Course)
                      .WithMany(c => c.Batches)
                      .HasForeignKey(b => b.CourseId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasIndex(e => new { e.StudentId, e.BatchId }).IsUnique();

                entity.HasOne(e => e.Student)
                      .WithMany(s => s.Enrollments)
                      .HasForeignKey(e => e.StudentId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Batch)
                      .WithMany(b => b.Enrollments)
                      .HasForeignKey(e => e.BatchId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // FIXED: Changed DeleteBehavior.Cascade to Restrict to resolve SQL Server Error 1785
            modelBuilder.Entity<LessonProgress>(entity =>
            {
                entity.HasIndex(lp => new { lp.EnrollmentId, lp.LessonId }).IsUnique();

                entity.HasOne(lp => lp.Enrollment)
                      .WithMany(e => e.LessonProgresses)
                      .HasForeignKey(lp => lp.EnrollmentId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(lp => lp.Lesson)
                      .WithMany(l => l.ProgressRecords)
                      .HasForeignKey(lp => lp.LessonId)
                      .OnDelete(DeleteBehavior.Restrict); // Resolves SQL Multiple Cascade Path issue
            });

            // 4. Live Class & Attendance
            modelBuilder.Entity<LiveClass>(entity =>
            {
                entity.HasOne(lc => lc.Batch)
                      .WithMany(b => b.LiveClasses)
                      .HasForeignKey(lc => lc.BatchId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(lc => lc.Instructor)
                      .WithMany(i => i.LiveClasses)
                      .HasForeignKey(lc => lc.InstructorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasIndex(a => new { a.LiveClassId, a.StudentId }).IsUnique();

                entity.HasOne(a => a.LiveClass)
                      .WithMany(lc => lc.Attendances)
                      .HasForeignKey(a => a.LiveClassId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.Student)
                      .WithMany(s => s.Attendances)
                      .HasForeignKey(a => a.StudentId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Enrollment)
                      .WithMany(e => e.Attendances)
                      .HasForeignKey(a => a.EnrollmentId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            // 5. Assignments & Quizzes
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasOne(a => a.Outline)
                      .WithMany(co => co.Assignments)
                      .HasForeignKey(a => a.OutlineId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AssignmentSubmission>(entity =>
            {
                entity.HasIndex(s => new { s.AssignmentId, s.StudentId }).IsUnique();

                entity.HasOne(s => s.Assignment)
                      .WithMany(a => a.Submissions)
                      .HasForeignKey(s => s.AssignmentId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.Student)
                      .WithMany(sp => sp.Submissions)
                      .HasForeignKey(s => s.StudentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.HasOne(q => q.Outline)
                      .WithMany(co => co.Quizzes)
                      .HasForeignKey(q => q.OutlineId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<QuizQuestion>(entity =>
            {
                entity.HasOne(qq => qq.Quiz)
                      .WithMany(q => q.Questions)
                      .HasForeignKey(qq => qq.QuizId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<QuizAttempt>(entity =>
            {
                entity.HasOne(qa => qa.Quiz)
                      .WithMany(q => q.Attempts)
                      .HasForeignKey(qa => qa.QuizId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(qa => qa.Student)
                      .WithMany(sp => sp.QuizAttempts)
                      .HasForeignKey(qa => qa.StudentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 6. Payments & Reviews
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(p => p.Amount).HasColumnType("decimal(18, 2)");
                entity.HasOne(p => p.Enrollment)
                      .WithMany(e => e.Payments)
                      .HasForeignKey(p => p.EnrollmentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TransactionReport>(entity =>
            {
                entity.Property(tr => tr.Amount).HasColumnType("decimal(18, 2)");
                entity.HasOne(tr => tr.Account)
                      .WithMany(a => a.Transactions)
                      .HasForeignKey(tr => tr.AccountId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(tr => tr.Payment)
                      .WithOne(p => p.TransactionReport)
                      .HasForeignKey<TransactionReport>(tr => tr.PaymentId)
                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<CourseReview>(entity =>
            {
                entity.HasIndex(r => new { r.CourseId, r.StudentId }).IsUnique();
                entity.HasOne(cr => cr.Course)
                      .WithMany(c => c.Reviews)
                      .HasForeignKey(cr => cr.CourseId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(cr => cr.Student)
                      .WithMany(sp => sp.CourseReviews)
                      .HasForeignKey(cr => cr.StudentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // 7. AI Q/A
            modelBuilder.Entity<AiCourseQuery>(entity =>
            {
                entity.HasOne(ai => ai.Course)
                      .WithMany(c => c.AiQueries)
                      .HasForeignKey(ai => ai.CourseId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ai => ai.Student)
                      .WithMany(sp => sp.AiCourseQueries)
                      .HasForeignKey(ai => ai.StudentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

//using CRM.Entities;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CRM.DataAccess
//{
//    public class ApplicationDbContext : DbContext
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//            : base(options)
//        {
//        }

//        public DbSet<Course> Courses { get; set; }
//        //public DbSet<Instructor> Instructors { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            modelBuilder.Entity<Course>(entity =>
//            {
//                entity.Property(x => x.Price)
//                      .HasPrecision(18, 2);
//            });

//            modelBuilder.Entity<Course>()
//         .ToTable("Course");


//        }
//    }
//}