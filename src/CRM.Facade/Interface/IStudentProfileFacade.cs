using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface IStudentProfileFacade
    {
        Task<List<StudentProfile>> GetStudentProfilesAsync();
        Task<StudentProfile?> GetStudentProfileByIdAsync(int id);
        Task AddStudentProfileAsync(StudentProfile studentProfile);
        Task<bool> UpdateStudentProfileAsync(StudentProfile studentProfile);
        Task<bool> DeleteStudentProfileAsync(int id);
    }
}
