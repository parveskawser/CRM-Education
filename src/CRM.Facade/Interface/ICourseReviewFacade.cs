using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface ICourseReviewFacade
    {
        Task<List<CourseReview>> GetCourseReviewsAsync();
        Task<CourseReview?> GetCourseReviewByIdAsync(int id);
        Task AddCourseReviewAsync(CourseReview courseReview);
        Task<bool> UpdateCourseReviewAsync(CourseReview courseReview);
        Task<bool> DeleteCourseReviewAsync(int id);
    }
}
