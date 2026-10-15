using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade
{
    public class AttendanceFacade : IAttendanceFacade
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceFacade(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<List<Attendance>> GetAttendancesAsync()
        {
            return await _attendanceRepository.GetAllAsync();
        }

        public async Task<Attendance?> GetAttendanceByIdAsync(int id)
        {
            return await _attendanceRepository.GetByIdAsync(id);
        }

        public async Task AddAttendanceAsync(Attendance attendance)
        {
            ArgumentNullException.ThrowIfNull(attendance);
            await _attendanceRepository.AddAsync(attendance);
        }

        public async Task<bool> UpdateAttendanceAsync(Attendance attendance)
        {
            ArgumentNullException.ThrowIfNull(attendance);

            var existing = await _attendanceRepository.GetByIdAsync(attendance.AttendanceId);
            if (existing == null)
                return false;

            await _attendanceRepository.UpdateAsync(attendance);
            return true;
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            var existing = await _attendanceRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _attendanceRepository.DeleteAsync(id);
            return true;
        }
    }
}
