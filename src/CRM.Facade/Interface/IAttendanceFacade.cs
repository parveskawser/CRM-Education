using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface IAttendanceFacade
    {
        Task<List<Attendance>> GetAttendancesAsync();
        Task<Attendance?> GetAttendanceByIdAsync(int id);
        Task AddAttendanceAsync(Attendance attendance);
        Task<bool> UpdateAttendanceAsync(Attendance attendance);
        Task<bool> DeleteAttendanceAsync(int id);
    }
}
