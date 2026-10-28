using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess.Implementation
{
    public class LiveClassRepository : ILiveClassRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LiveClassRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LiveClass>> GetAllAsync()
        {
            return await _dbContext.LiveClasses
                .OrderByDescending(x => x.LiveClassId)
                .ToListAsync();
        }

        public async Task<LiveClass?> GetByIdAsync(int id)
        {
            return await _dbContext.LiveClasses.FindAsync(id);
        }

        public async Task AddAsync(LiveClass liveClass)
        {
            await _dbContext.LiveClasses.AddAsync(liveClass);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(LiveClass liveClass)
        {
            _dbContext.LiveClasses.Update(liveClass);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var liveClass = await _dbContext.LiveClasses.FindAsync(id);

            if (liveClass == null)
                return;

            _dbContext.LiveClasses.Remove(liveClass);
            await _dbContext.SaveChangesAsync();
        }
    }
}