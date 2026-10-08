using System;

namespace CRM.Entities
{
    public class ReportDefinition
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string ReportType { get; set; } = "Course";

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public object Student { get; set; }
    }


    public class StudentReport
    {
        public Students Student { get; set; }
        public List<Course> CourseList { get; set; }

    }


}