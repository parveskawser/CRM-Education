using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess.Implementation
{
    public class AiCourseQueryRepository : IAiCourseQueryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AiCourseQueryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AiCourseQuery>> GetAllAsync()
        {
            return await _dbContext.AiCourseQueries
                .OrderByDescending(x => x.QueryId)
                .ToListAsync();
        }

        public async Task<AiCourseQuery?> GetByIdAsync(int id)
        {
            return await _dbContext.AiCourseQueries.FindAsync(id);
        }

        public async Task AddAsync(AiCourseQuery aiCourseQuery)
        {
            await _dbContext.AiCourseQueries.AddAsync(aiCourseQuery);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(AiCourseQuery aiCourseQuery)
        {
            _dbContext.AiCourseQueries.Update(aiCourseQuery);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var aiCourseQuery = await _dbContext.AiCourseQueries.FindAsync(id);

            if (aiCourseQuery == null)
                return;

            _dbContext.AiCourseQueries.Remove(aiCourseQuery);
            await _dbContext.SaveChangesAsync();
        }
    }
}