using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess
{
    public class InstructorProfileRepository : IInstructorProfileRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InstructorProfileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<InstructorProfile>> GetAllAsync()
        {
            return await _dbContext.InstructorProfiles
                .OrderByDescending(x => x.UserId)
                .ToListAsync();
        }

        public async Task<InstructorProfile?> GetByIdAsync(int id)
        {
            return await _dbContext.InstructorProfiles.FindAsync(id);
        }

        public async Task AddAsync(InstructorProfile instructorProfile)
        {
            await _dbContext.InstructorProfiles.AddAsync(instructorProfile);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(InstructorProfile instructorProfile)
        {
            _dbContext.InstructorProfiles.Update(instructorProfile);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var instructorProfile = await _dbContext.InstructorProfiles.FindAsync(id);

            if (instructorProfile == null)
                return;

            _dbContext.InstructorProfiles.Remove(instructorProfile);
            await _dbContext.SaveChangesAsync();
        }
    }
}