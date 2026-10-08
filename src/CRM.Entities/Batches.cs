using System;

namespace CRM.Entities
{
    public class Batch
    {
        public int Id { get; set; }

        public string BatchName { get; set; } = string.Empty;

        public int CourseId { get; set; }

        public string Schedule { get; set; } = string.Empty;

        public int Capacity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Status { get; set; } = "Scheduled";
        // Active, Scheduled, Completed, Cancelled

        public bool IsActive { get; set; }
    }
    public class Batches
    {
        public List<Batch> BatchList { get; set; }
        public List<Course> CourseList { get; set; }
    }

}