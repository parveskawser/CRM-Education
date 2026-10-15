using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface ILessonFacade
    {
        Task<List<Lesson>> GetLessonsAsync();
        Task<Lesson?> GetLessonByIdAsync(int id);
        Task AddLessonAsync(Lesson lesson);
        Task<bool> UpdateLessonAsync(Lesson lesson);
        Task<bool> DeleteLessonAsync(int id);
    }
}
