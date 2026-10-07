using System;

namespace CRM.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; } = string.Empty;

        public int CourseId { get; set; }
        public int BatchId { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string Status { get; set; } = "Active";
    }
}