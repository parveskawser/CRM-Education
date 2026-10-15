using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface IAssignmentSubmissionFacade
    {
        Task<List<AssignmentSubmission>> GetAssignmentSubmissionsAsync();
        Task<AssignmentSubmission?> GetAssignmentSubmissionByIdAsync(int id);
        Task AddAssignmentSubmissionAsync(AssignmentSubmission assignmentSubmission);
        Task<bool> UpdateAssignmentSubmissionAsync(AssignmentSubmission assignmentSubmission);
        Task<bool> DeleteAssignmentSubmissionAsync(int id);
    }
}
