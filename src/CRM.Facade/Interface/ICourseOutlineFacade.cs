using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface ICourseOutlineFacade
    {
        Task<List<CourseOutline>> GetCourseOutlinesAsync();
        Task<CourseOutline?> GetCourseOutlineByIdAsync(int id);
        Task AddCourseOutlineAsync(CourseOutline courseOutline);
        Task<bool> UpdateCourseOutlineAsync(CourseOutline courseOutline);
        Task<bool> DeleteCourseOutlineAsync(int id);
    }
}
