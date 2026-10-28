using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess.Implementation
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EnrollmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Enrollment>> GetAllAsync()
        {
            return await _dbContext.Enrollments
                .OrderByDescending(x => x.EnrollmentId)
                .ToListAsync();
        }

        public async Task<Enrollment?> GetByIdAsync(int id)
        {
            return await _dbContext.Enrollments.FindAsync(id);
        }

        public async Task AddAsync(Enrollment enrollment)
        {
            await _dbContext.Enrollments.AddAsync(enrollment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Enrollment enrollment)
        {
            _dbContext.Enrollments.Update(enrollment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var enrollment = await _dbContext.Enrollments.FindAsync(id);

            if (enrollment == null)
                return;

            _dbContext.Enrollments.Remove(enrollment);
            await _dbContext.SaveChangesAsync();
        }
    }
}