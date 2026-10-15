using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
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
}
