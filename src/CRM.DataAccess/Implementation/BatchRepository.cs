using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess.Implementation
{
    public class BatchRepository : IBatchRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BatchRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Batch>> GetAllAsync()
        {
            return await _dbContext.Batches
                .OrderByDescending(x => x.BatchId)
                .ToListAsync();
        }

        public async Task<Batch?> GetByIdAsync(int id)
        {
            return await _dbContext.Batches.FindAsync(id);
        }

        public async Task AddAsync(Batch batch)
        {
            await _dbContext.Batches.AddAsync(batch);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Batch batch)
        {
            _dbContext.Batches.Update(batch);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var batch = await _dbContext.Batches.FindAsync(id);

            if (batch == null)
                return;

            _dbContext.Batches.Remove(batch);
            await _dbContext.SaveChangesAsync();
        }
    }
}