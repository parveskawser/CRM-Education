using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess.Implementation
{
    public class AssignmentSubmissionRepository : IAssignmentSubmissionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AssignmentSubmissionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AssignmentSubmission>> GetAllAsync()
        {
            return await _dbContext.AssignmentSubmissions
                .OrderByDescending(x => x.SubmissionId)
                .ToListAsync();
        }

        public async Task<AssignmentSubmission?> GetByIdAsync(int id)
        {
            return await _dbContext.AssignmentSubmissions.FindAsync(id);
        }

        public async Task AddAsync(AssignmentSubmission assignmentSubmission)
        {
            await _dbContext.AssignmentSubmissions.AddAsync(assignmentSubmission);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(AssignmentSubmission assignmentSubmission)
        {
            _dbContext.AssignmentSubmissions.Update(assignmentSubmission);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var assignmentSubmission = await _dbContext.AssignmentSubmissions.FindAsync(id);

            if (assignmentSubmission == null)
                return;

            _dbContext.AssignmentSubmissions.Remove(assignmentSubmission);
            await _dbContext.SaveChangesAsync();
        }
    }
}