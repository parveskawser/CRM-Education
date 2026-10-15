using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade
{
    public class InstructorProfileFacade : IInstructorProfileFacade
    {
        private readonly IInstructorProfileRepository _instructorProfileRepository;

        public InstructorProfileFacade(IInstructorProfileRepository instructorProfileRepository)
        {
            _instructorProfileRepository = instructorProfileRepository;
        }

        public async Task<List<InstructorProfile>> GetInstructorProfilesAsync()
        {
            return await _instructorProfileRepository.GetAllAsync();
        }

        public async Task<InstructorProfile?> GetInstructorProfileByIdAsync(int id)
        {
            return await _instructorProfileRepository.GetByIdAsync(id);
        }

        public async Task AddInstructorProfileAsync(InstructorProfile instructorProfile)
        {
            ArgumentNullException.ThrowIfNull(instructorProfile);
            await _instructorProfileRepository.AddAsync(instructorProfile);
        }

        public async Task<bool> UpdateInstructorProfileAsync(InstructorProfile instructorProfile)
        {
            ArgumentNullException.ThrowIfNull(instructorProfile);

            var existing = await _instructorProfileRepository.GetByIdAsync(instructorProfile.UserId);
            if (existing == null)
                return false;

            await _instructorProfileRepository.UpdateAsync(instructorProfile);
            return true;
        }

        public async Task<bool> DeleteInstructorProfileAsync(int id)
        {
            var existing = await _instructorProfileRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _instructorProfileRepository.DeleteAsync(id);
            return true;
        }
    }
}
