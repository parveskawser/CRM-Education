using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }

        public string? ThumbnailUrl { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }

        public int InstructorId { get; set; }
        public int CategoryId { get; set; }

        public string Level { get; set; } = "Beginner"; // Beginner, Intermediate, Advanced
        public string Language { get; set; } = "Bangla";

        public int TotalLessons { get; set; }
        public int DurationInMinutes { get; set; }

        public bool IsPublished { get; set; }
        public bool IsFeatured { get; set; }

    }

    public class StudentCourse
    {
        public Students Student { get; set;  }
        public List<Course> CourseList { get; set;  }

    }
}
