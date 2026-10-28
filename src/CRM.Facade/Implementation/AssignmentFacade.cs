using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade.Implementation
{
    public class AssignmentFacade : IAssignmentFacade
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentFacade(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<List<Assignment>> GetAssignmentsAsync()
        {
            return await _assignmentRepository.GetAllAsync();
        }

        public async Task<Assignment?> GetAssignmentByIdAsync(int id)
        {
            return await _assignmentRepository.GetByIdAsync(id);
        }

        public async Task AddAssignmentAsync(Assignment assignment)
        {
            ArgumentNullException.ThrowIfNull(assignment);
            await _assignmentRepository.AddAsync(assignment);
        }

        public async Task<bool> UpdateAssignmentAsync(Assignment assignment)
        {
            ArgumentNullException.ThrowIfNull(assignment);

            var existing = await _assignmentRepository.GetByIdAsync(assignment.AssignmentId);
            if (existing == null)
                return false;

            await _assignmentRepository.UpdateAsync(assignment);
            return true;
        }

        public async Task<bool> DeleteAssignmentAsync(int id)
        {
            var existing = await _assignmentRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _assignmentRepository.DeleteAsync(id);
            return true;
        }
    }
}
