using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Interface
{
    public interface IAssignmentSubmissionRepository
    {
        Task<List<AssignmentSubmission>> GetAllAsync();
        Task<AssignmentSubmission?> GetByIdAsync(int id);
        Task AddAsync(AssignmentSubmission assignmentSubmission);
        Task UpdateAsync(AssignmentSubmission assignmentSubmission);
        Task DeleteAsync(int id);
    }
}