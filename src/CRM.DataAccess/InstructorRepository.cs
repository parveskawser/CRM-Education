using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess
{
    public class InstructorRepository: IInstructorRepository
    {

        private readonly ApplicationDbContext _dbContext;

        public InstructorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Instructor>> GetAllAsync()
        {
            return await _dbContext.Instructors
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task<Instructor?> GetByIdAsync(int id)
        {
            return await _dbContext.Instructors.FindAsync(id);
        }

        public async Task AddAsync(Instructor instructor)
        {
            await _dbContext.Instructors.AddAsync(instructor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Instructor instructor)
        {
            _dbContext.Instructors.Update(instructor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _dbContext.Courses.FindAsync(id);

            if (course == null)
                return;

            _dbContext.Courses.Remove(course);
            await _dbContext.SaveChangesAsync();
        }
    }
}
