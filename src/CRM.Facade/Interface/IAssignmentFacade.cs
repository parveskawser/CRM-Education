using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface IAssignmentFacade
    {
        Task<List<Assignment>> GetAssignmentsAsync();
        Task<Assignment?> GetAssignmentByIdAsync(int id);
        Task AddAssignmentAsync(Assignment assignment);
        Task<bool> UpdateAssignmentAsync(Assignment assignment);
        Task<bool> DeleteAssignmentAsync(int id);
    }
}
