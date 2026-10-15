using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AssignmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Assignment>> GetAllAsync()
        {
            return await _dbContext.Assignments
                .OrderByDescending(x => x.AssignmentId)
                .ToListAsync();
        }

        public async Task<Assignment?> GetByIdAsync(int id)
        {
            return await _dbContext.Assignments.FindAsync(id);
        }

        public async Task AddAsync(Assignment assignment)
        {
            await _dbContext.Assignments.AddAsync(assignment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Assignment assignment)
        {
            _dbContext.Assignments.Update(assignment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var assignment = await _dbContext.Assignments.FindAsync(id);

            if (assignment == null)
                return;

            _dbContext.Assignments.Remove(assignment);
            await _dbContext.SaveChangesAsync();
        }
    }
}