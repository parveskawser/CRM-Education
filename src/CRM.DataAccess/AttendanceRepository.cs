using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AttendanceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Attendance>> GetAllAsync()
        {
            return await _dbContext.Attendances
                .OrderByDescending(x => x.AttendanceId)
                .ToListAsync();
        }

        public async Task<Attendance?> GetByIdAsync(int id)
        {
            return await _dbContext.Attendances.FindAsync(id);
        }

        public async Task AddAsync(Attendance attendance)
        {
            await _dbContext.Attendances.AddAsync(attendance);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Attendance attendance)
        {
            _dbContext.Attendances.Update(attendance);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var attendance = await _dbContext.Attendances.FindAsync(id);

            if (attendance == null)
                return;

            _dbContext.Attendances.Remove(attendance);
            await _dbContext.SaveChangesAsync();
        }
    }
}