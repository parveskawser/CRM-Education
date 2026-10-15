using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade
{
    public class CourseReviewFacade : ICourseReviewFacade
    {
        private readonly ICourseReviewRepository _courseReviewRepository;

        public CourseReviewFacade(ICourseReviewRepository courseReviewRepository)
        {
            _courseReviewRepository = courseReviewRepository;
        }

        public async Task<List<CourseReview>> GetCourseReviewsAsync()
        {
            return await _courseReviewRepository.GetAllAsync();
        }

        public async Task<CourseReview?> GetCourseReviewByIdAsync(int id)
        {
            return await _courseReviewRepository.GetByIdAsync(id);
        }

        public async Task AddCourseReviewAsync(CourseReview courseReview)
        {
            ArgumentNullException.ThrowIfNull(courseReview);
            await _courseReviewRepository.AddAsync(courseReview);
        }

        public async Task<bool> UpdateCourseReviewAsync(CourseReview courseReview)
        {
            ArgumentNullException.ThrowIfNull(courseReview);

            var existing = await _courseReviewRepository.GetByIdAsync(courseReview.ReviewId);
            if (existing == null)
                return false;

            await _courseReviewRepository.UpdateAsync(courseReview);
            return true;
        }

        public async Task<bool> DeleteCourseReviewAsync(int id)
        {
            var existing = await _courseReviewRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _courseReviewRepository.DeleteAsync(id);
            return true;
        }
    }
}
