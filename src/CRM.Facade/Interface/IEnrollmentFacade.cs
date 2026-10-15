using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface IEnrollmentFacade
    {
        Task<List<Enrollment>> GetEnrollmentsAsync();
        Task<Enrollment?> GetEnrollmentByIdAsync(int id);
        Task AddEnrollmentAsync(Enrollment enrollment);
        Task<bool> UpdateEnrollmentAsync(Enrollment enrollment);
        Task<bool> DeleteEnrollmentAsync(int id);
    }
}
