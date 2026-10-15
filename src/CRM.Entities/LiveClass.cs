using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
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
}
