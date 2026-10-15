using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface ILessonProgressFacade
    {
        Task<List<LessonProgress>> GetLessonProgressesAsync();
        Task<LessonProgress?> GetLessonProgressByIdAsync(int id);
        Task AddLessonProgressAsync(LessonProgress lessonProgress);
        Task<bool> UpdateLessonProgressAsync(LessonProgress lessonProgress);
        Task<bool> DeleteLessonProgressAsync(int id);
    }
}
