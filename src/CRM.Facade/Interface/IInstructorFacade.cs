using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Facade.Interface
{
    public interface IInstructorFacade
    {
        Task<List<Instructor>> GetInstructorsAsync();
        Task<Instructor?> GetInstructorByIdAsync(int id);
        Task AddInstructorAsync(Instructor Instructor);
        Task<bool> UpdateInstructorAsync(Instructor Instructor);
        Task<bool> DeleteInstructorAsync(int id);
    }
}
