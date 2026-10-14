using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace CRM.Facade.Interface
{
    public interface ICourseFacade
    {
        Task<List<Course>> GetCoursesAsync();
        Task<Course?> GetCourseByIdAsync(int id);
        Task AddCourseAsync(Course course);
        Task<bool> UpdateCourseAsync(Course course);
        Task<bool> DeleteCourseAsync(int id);
    }
}
