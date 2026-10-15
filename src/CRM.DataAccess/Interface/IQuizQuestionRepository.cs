using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Interface
{
    public interface IQuizQuestionRepository
    {
        Task<List<QuizQuestion>> GetAllAsync();
        Task<QuizQuestion?> GetByIdAsync(int id);
        Task AddAsync(QuizQuestion quizQuestion);
        Task UpdateAsync(QuizQuestion quizQuestion);
        Task DeleteAsync(int id);
    }
}