using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade
{
    public class EnrollmentFacade : IEnrollmentFacade
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentFacade(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<List<Enrollment>> GetEnrollmentsAsync()
        {
            return await _enrollmentRepository.GetAllAsync();
        }

        public async Task<Enrollment?> GetEnrollmentByIdAsync(int id)
        {
            return await _enrollmentRepository.GetByIdAsync(id);
        }

        public async Task AddEnrollmentAsync(Enrollment enrollment)
        {
            ArgumentNullException.ThrowIfNull(enrollment);
            await _enrollmentRepository.AddAsync(enrollment);
        }

        public async Task<bool> UpdateEnrollmentAsync(Enrollment enrollment)
        {
            ArgumentNullException.ThrowIfNull(enrollment);

            var existing = await _enrollmentRepository.GetByIdAsync(enrollment.EnrollmentId);
            if (existing == null)
                return false;

            await _enrollmentRepository.UpdateAsync(enrollment);
            return true;
        }

        public async Task<bool> DeleteEnrollmentAsync(int id)
        {
            var existing = await _enrollmentRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _enrollmentRepository.DeleteAsync(id);
            return true;
        }
    }
}
