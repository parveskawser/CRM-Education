using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess
{
    public class QuizQuestionRepository : IQuizQuestionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public QuizQuestionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<QuizQuestion>> GetAllAsync()
        {
            return await _dbContext.QuizQuestions
                .OrderByDescending(x => x.QuestionId)
                .ToListAsync();
        }

        public async Task<QuizQuestion?> GetByIdAsync(int id)
        {
            return await _dbContext.QuizQuestions.FindAsync(id);
        }

        public async Task AddAsync(QuizQuestion quizQuestion)
        {
            await _dbContext.QuizQuestions.AddAsync(quizQuestion);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(QuizQuestion quizQuestion)
        {
            _dbContext.QuizQuestions.Update(quizQuestion);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var quizQuestion = await _dbContext.QuizQuestions.FindAsync(id);

            if (quizQuestion == null)
                return;

            _dbContext.QuizQuestions.Remove(quizQuestion);
            await _dbContext.SaveChangesAsync();
        }
    }
}