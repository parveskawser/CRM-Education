using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess
{
    public class CourseOutlineRepository : ICourseOutlineRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CourseOutlineRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CourseOutline>> GetAllAsync()
        {
            return await _dbContext.CourseOutlines
                .OrderByDescending(x => x.OutlineId)
                .ToListAsync();
        }

        public async Task<CourseOutline?> GetByIdAsync(int id)
        {
            return await _dbContext.CourseOutlines.FindAsync(id);
        }

        public async Task AddAsync(CourseOutline courseOutline)
        {
            await _dbContext.CourseOutlines.AddAsync(courseOutline);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CourseOutline courseOutline)
        {
            _dbContext.CourseOutlines.Update(courseOutline);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var courseOutline = await _dbContext.CourseOutlines.FindAsync(id);

            if (courseOutline == null)
                return;

            _dbContext.CourseOutlines.Remove(courseOutline);
            await _dbContext.SaveChangesAsync();
        }
    }
}