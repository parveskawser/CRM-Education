using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Interface
{
    public interface IAssignmentRepository
    {
        Task<List<Assignment>> GetAllAsync();
        Task<Assignment?> GetByIdAsync(int id);
        Task AddAsync(Assignment assignment);
        Task UpdateAsync(Assignment assignment);
        Task DeleteAsync(int id);
    }
}