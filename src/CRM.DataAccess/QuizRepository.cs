using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public QuizRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Quiz>> GetAllAsync()
        {
            return await _dbContext.Quizzes
                .OrderByDescending(x => x.QuizId)
                .ToListAsync();
        }

        public async Task<Quiz?> GetByIdAsync(int id)
        {
            return await _dbContext.Quizzes.FindAsync(id);
        }

        public async Task AddAsync(Quiz quiz)
        {
            await _dbContext.Quizzes.AddAsync(quiz);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Quiz quiz)
        {
            _dbContext.Quizzes.Update(quiz);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var quiz = await _dbContext.Quizzes.FindAsync(id);

            if (quiz == null)
                return;

            _dbContext.Quizzes.Remove(quiz);
            await _dbContext.SaveChangesAsync();
        }
    }
}