using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess
{
    public class LessonProgressRepository : ILessonProgressRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LessonProgressRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LessonProgress>> GetAllAsync()
        {
            return await _dbContext.LessonProgresses
                .OrderByDescending(x => x.ProgressId)
                .ToListAsync();
        }

        public async Task<LessonProgress?> GetByIdAsync(int id)
        {
            return await _dbContext.LessonProgresses.FindAsync(id);
        }

        public async Task AddAsync(LessonProgress lessonProgress)
        {
            await _dbContext.LessonProgresses.AddAsync(lessonProgress);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(LessonProgress lessonProgress)
        {
            _dbContext.LessonProgresses.Update(lessonProgress);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lessonProgress = await _dbContext.LessonProgresses.FindAsync(id);

            if (lessonProgress == null)
                return;

            _dbContext.LessonProgresses.Remove(lessonProgress);
            await _dbContext.SaveChangesAsync();
        }
    }
}