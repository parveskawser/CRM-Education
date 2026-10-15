using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Interface
{
    public interface ILessonProgressRepository
    {
        Task<List<LessonProgress>> GetAllAsync();
        Task<LessonProgress?> GetByIdAsync(int id);
        Task AddAsync(LessonProgress lessonProgress);
        Task UpdateAsync(LessonProgress lessonProgress);
        Task DeleteAsync(int id);
    }
}