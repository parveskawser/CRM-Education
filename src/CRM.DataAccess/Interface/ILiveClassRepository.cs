using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Interface
{
    public interface ILiveClassRepository
    {
        Task<List<LiveClass>> GetAllAsync();
        Task<LiveClass?> GetByIdAsync(int id);
        Task AddAsync(LiveClass liveClass);
        Task UpdateAsync(LiveClass liveClass);
        Task DeleteAsync(int id);
    }
}