using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Entities
{
    public class Instructor
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }

        
        public string? Bio { get; set; }

        public string? Expertise { get; set; }
        public string? Qualification { get; set; }

        public int ExperienceYears { get; set; }

        public bool IsActive { get; set; }
    }
}