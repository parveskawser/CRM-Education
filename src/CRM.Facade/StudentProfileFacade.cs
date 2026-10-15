using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade
{
    public class StudentProfileFacade : IStudentProfileFacade
    {
        private readonly IStudentProfileRepository _studentProfileRepository;

        public StudentProfileFacade(IStudentProfileRepository studentProfileRepository)
        {
            _studentProfileRepository = studentProfileRepository;
        }

        public async Task<List<StudentProfile>> GetStudentProfilesAsync()
        {
            return await _studentProfileRepository.GetAllAsync();
        }

        public async Task<StudentProfile?> GetStudentProfileByIdAsync(int id)
        {
            return await _studentProfileRepository.GetByIdAsync(id);
        }

        public async Task AddStudentProfileAsync(StudentProfile studentProfile)
        {
            ArgumentNullException.ThrowIfNull(studentProfile);
            await _studentProfileRepository.AddAsync(studentProfile);
        }

        public async Task<bool> UpdateStudentProfileAsync(StudentProfile studentProfile)
        {
            ArgumentNullException.ThrowIfNull(studentProfile);

            var existing = await _studentProfileRepository.GetByIdAsync(studentProfile.UserId);
            if (existing == null)
                return false;

            await _studentProfileRepository.UpdateAsync(studentProfile);
            return true;
        }

        public async Task<bool> DeleteStudentProfileAsync(int id)
        {
            var existing = await _studentProfileRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _studentProfileRepository.DeleteAsync(id);
            return true;
        }
    }
}
