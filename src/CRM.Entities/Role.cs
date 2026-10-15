using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRM.Entities
{
    public class Role
    {

        [Key]
        public int RoleId { get; set; }

        [Required, StringLength(50)]
        public string RoleName { get; set; } = string.Empty; // e.g., Admin, Instructor, Student

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
