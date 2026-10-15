using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Interface
{
    public interface IBatchRepository
    {
        Task<List<Batch>> GetAllAsync();
        Task<Batch?> GetByIdAsync(int id);
        Task AddAsync(Batch batch);
        Task UpdateAsync(Batch batch);
        Task DeleteAsync(int id);
    }
}