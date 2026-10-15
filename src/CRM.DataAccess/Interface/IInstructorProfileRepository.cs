using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Interface
{
    public interface IInstructorProfileRepository
    {
        Task<List<InstructorProfile>> GetAllAsync();
        Task<InstructorProfile?> GetByIdAsync(int id);
        Task AddAsync(InstructorProfile instructorProfile);
        Task UpdateAsync(InstructorProfile instructorProfile);
        Task DeleteAsync(int id);
    }
}