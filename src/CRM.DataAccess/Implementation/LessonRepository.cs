using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess.Implementation
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LessonRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Lesson>> GetAllAsync()
        {
            return await _dbContext.Lessons
                .OrderByDescending(x => x.LessonId)
                .ToListAsync();
        }

        public async Task<Lesson?> GetByIdAsync(int id)
        {
            return await _dbContext.Lessons.FindAsync(id);
        }

        public async Task AddAsync(Lesson lesson)
        {
            await _dbContext.Lessons.AddAsync(lesson);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Lesson lesson)
        {
            _dbContext.Lessons.Update(lesson);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lesson = await _dbContext.Lessons.FindAsync(id);

            if (lesson == null)
                return;

            _dbContext.Lessons.Remove(lesson);
            await _dbContext.SaveChangesAsync();
        }
    }
}