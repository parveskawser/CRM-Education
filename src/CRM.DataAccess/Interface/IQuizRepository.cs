using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Interface
{
    public interface IQuizRepository
    {
        Task<List<Quiz>> GetAllAsync();
        Task<Quiz?> GetByIdAsync(int id);
        Task AddAsync(Quiz quiz);
        Task UpdateAsync(Quiz quiz);
        Task DeleteAsync(int id);
    }
}