using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Interface
{
    public interface ILessonRepository
    {
        Task<List<Lesson>> GetAllAsync();
        Task<Lesson?> GetByIdAsync(int id);
        Task AddAsync(Lesson lesson);
        Task UpdateAsync(Lesson lesson);
        Task DeleteAsync(int id);
    }
}