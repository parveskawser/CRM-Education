using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Interface
{
    public interface IAiCourseQueryRepository
    {
        Task<List<AiCourseQuery>> GetAllAsync();
        Task<AiCourseQuery?> GetByIdAsync(int id);
        Task AddAsync(AiCourseQuery aiCourseQuery);
        Task UpdateAsync(AiCourseQuery aiCourseQuery);
        Task DeleteAsync(int id);
    }
}