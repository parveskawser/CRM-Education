using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface IInstructorProfileFacade
    {
        Task<List<InstructorProfile>> GetInstructorProfilesAsync();
        Task<InstructorProfile?> GetInstructorProfileByIdAsync(int id);
        Task AddInstructorProfileAsync(InstructorProfile instructorProfile);
        Task<bool> UpdateInstructorProfileAsync(InstructorProfile instructorProfile);
        Task<bool> DeleteInstructorProfileAsync(int id);
    }
}
