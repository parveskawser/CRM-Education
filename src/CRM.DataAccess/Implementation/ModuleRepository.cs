using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess.Implementation
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ModuleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Module>> GetAllAsync()
        {
            return await _dbContext.Modules
                .OrderByDescending(x => x.ModuleId)
                .ToListAsync();
        }

        public async Task<Module?> GetByIdAsync(int id)
        {
            return await _dbContext.Modules.FindAsync(id);
        }

        public async Task AddAsync(Module module)
        {
            await _dbContext.Modules.AddAsync(module);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Module module)
        {
            _dbContext.Modules.Update(module);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var module = await _dbContext.Modules.FindAsync(id);

            if (module == null)
                return;

            _dbContext.Modules.Remove(module);
            await _dbContext.SaveChangesAsync();
        }
    }
}