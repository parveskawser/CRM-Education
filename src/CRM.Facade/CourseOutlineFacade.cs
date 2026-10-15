using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade
{
    public class CourseOutlineFacade : ICourseOutlineFacade
    {
        private readonly ICourseOutlineRepository _courseOutlineRepository;

        public CourseOutlineFacade(ICourseOutlineRepository courseOutlineRepository)
        {
            _courseOutlineRepository = courseOutlineRepository;
        }

        public async Task<List<CourseOutline>> GetCourseOutlinesAsync()
        {
            return await _courseOutlineRepository.GetAllAsync();
        }

        public async Task<CourseOutline?> GetCourseOutlineByIdAsync(int id)
        {
            return await _courseOutlineRepository.GetByIdAsync(id);
        }

        public async Task AddCourseOutlineAsync(CourseOutline courseOutline)
        {
            ArgumentNullException.ThrowIfNull(courseOutline);
            await _courseOutlineRepository.AddAsync(courseOutline);
        }

        public async Task<bool> UpdateCourseOutlineAsync(CourseOutline courseOutline)
        {
            ArgumentNullException.ThrowIfNull(courseOutline);

            var existing = await _courseOutlineRepository.GetByIdAsync(courseOutline.OutlineId);
            if (existing == null)
                return false;

            await _courseOutlineRepository.UpdateAsync(courseOutline);
            return true;
        }

        public async Task<bool> DeleteCourseOutlineAsync(int id)
        {
            var existing = await _courseOutlineRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _courseOutlineRepository.DeleteAsync(id);
            return true;
        }
    }
}
