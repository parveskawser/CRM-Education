using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Interface
{
    public interface IQuizAttemptRepository
    {
        Task<List<QuizAttempt>> GetAllAsync();
        Task<QuizAttempt?> GetByIdAsync(int id);
        Task AddAsync(QuizAttempt quizAttempt);
        Task UpdateAsync(QuizAttempt quizAttempt);
        Task DeleteAsync(int id);
    }
}