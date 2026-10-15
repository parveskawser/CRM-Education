using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
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
}
