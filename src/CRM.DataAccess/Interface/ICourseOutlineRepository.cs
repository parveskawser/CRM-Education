using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Interface
{
    public interface ICourseOutlineRepository
    {
        Task<List<CourseOutline>> GetAllAsync();
        Task<CourseOutline?> GetByIdAsync(int id);
        Task AddAsync(CourseOutline courseOutline);
        Task UpdateAsync(CourseOutline courseOutline);
        Task DeleteAsync(int id);
    }
}