using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Interface
{
    public interface IModuleRepository
    {
        Task<List<Module>> GetAllAsync();
        Task<Module?> GetByIdAsync(int id);
        Task AddAsync(Module module);
        Task UpdateAsync(Module module);
        Task DeleteAsync(int id);
    }
}