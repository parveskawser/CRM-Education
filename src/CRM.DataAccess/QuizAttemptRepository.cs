using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess
{
    public class QuizAttemptRepository : IQuizAttemptRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public QuizAttemptRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<QuizAttempt>> GetAllAsync()
        {
            return await _dbContext.QuizAttempts
                .OrderByDescending(x => x.AttemptId)
                .ToListAsync();
        }

        public async Task<QuizAttempt?> GetByIdAsync(int id)
        {
            return await _dbContext.QuizAttempts.FindAsync(id);
        }

        public async Task AddAsync(QuizAttempt quizAttempt)
        {
            await _dbContext.QuizAttempts.AddAsync(quizAttempt);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(QuizAttempt quizAttempt)
        {
            _dbContext.QuizAttempts.Update(quizAttempt);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var quizAttempt = await _dbContext.QuizAttempts.FindAsync(id);

            if (quizAttempt == null)
                return;

            _dbContext.QuizAttempts.Remove(quizAttempt);
            await _dbContext.SaveChangesAsync();
        }
    }
}