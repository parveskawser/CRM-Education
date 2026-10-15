using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Interface
{
    public interface IStudentProfileRepository
    {
        Task<List<StudentProfile>> GetAllAsync();
        Task<StudentProfile?> GetByIdAsync(int id);
        Task AddAsync(StudentProfile studentProfile);
        Task UpdateAsync(StudentProfile studentProfile);
        Task DeleteAsync(int id);
    }
}