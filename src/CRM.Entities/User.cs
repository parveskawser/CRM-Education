using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.Entities
{
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
}
