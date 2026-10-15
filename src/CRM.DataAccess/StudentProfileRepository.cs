using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess
{
    public class StudentProfileRepository : IStudentProfileRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentProfileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StudentProfile>> GetAllAsync()
        {
            return await _dbContext.StudentProfiles
                .OrderByDescending(x => x.UserId)
                .ToListAsync();
        }

        public async Task<StudentProfile?> GetByIdAsync(int id)
        {
            return await _dbContext.StudentProfiles.FindAsync(id);
        }

        public async Task AddAsync(StudentProfile studentProfile)
        {
            await _dbContext.StudentProfiles.AddAsync(studentProfile);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(StudentProfile studentProfile)
        {
            _dbContext.StudentProfiles.Update(studentProfile);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var studentProfile = await _dbContext.StudentProfiles.FindAsync(id);

            if (studentProfile == null)
                return;

            _dbContext.StudentProfiles.Remove(studentProfile);
            await _dbContext.SaveChangesAsync();
        }
    }
}