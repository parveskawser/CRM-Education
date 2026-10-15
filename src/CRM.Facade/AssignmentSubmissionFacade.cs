using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade
{
    public class AssignmentSubmissionFacade : IAssignmentSubmissionFacade
    {
        private readonly IAssignmentSubmissionRepository _assignmentSubmissionRepository;

        public AssignmentSubmissionFacade(IAssignmentSubmissionRepository assignmentSubmissionRepository)
        {
            _assignmentSubmissionRepository = assignmentSubmissionRepository;
        }

        public async Task<List<AssignmentSubmission>> GetAssignmentSubmissionsAsync()
        {
            return await _assignmentSubmissionRepository.GetAllAsync();
        }

        public async Task<AssignmentSubmission?> GetAssignmentSubmissionByIdAsync(int id)
        {
            return await _assignmentSubmissionRepository.GetByIdAsync(id);
        }

        public async Task AddAssignmentSubmissionAsync(AssignmentSubmission assignmentSubmission)
        {
            ArgumentNullException.ThrowIfNull(assignmentSubmission);
            await _assignmentSubmissionRepository.AddAsync(assignmentSubmission);
        }

        public async Task<bool> UpdateAssignmentSubmissionAsync(AssignmentSubmission assignmentSubmission)
        {
            ArgumentNullException.ThrowIfNull(assignmentSubmission);

            var existing = await _assignmentSubmissionRepository.GetByIdAsync(assignmentSubmission.SubmissionId);
            if (existing == null)
                return false;

            await _assignmentSubmissionRepository.UpdateAsync(assignmentSubmission);
            return true;
        }

        public async Task<bool> DeleteAssignmentSubmissionAsync(int id)
        {
            var existing = await _assignmentSubmissionRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _assignmentSubmissionRepository.DeleteAsync(id);
            return true;
        }
    }
}
