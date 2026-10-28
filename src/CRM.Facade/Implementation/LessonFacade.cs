using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade.Implementation
{
    public class LessonFacade : ILessonFacade
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonFacade(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<List<Lesson>> GetLessonsAsync()
        {
            return await _lessonRepository.GetAllAsync();
        }

        public async Task<Lesson?> GetLessonByIdAsync(int id)
        {
            return await _lessonRepository.GetByIdAsync(id);
        }

        public async Task AddLessonAsync(Lesson lesson)
        {
            ArgumentNullException.ThrowIfNull(lesson);
            await _lessonRepository.AddAsync(lesson);
        }

        public async Task<bool> UpdateLessonAsync(Lesson lesson)
        {
            ArgumentNullException.ThrowIfNull(lesson);

            var existing = await _lessonRepository.GetByIdAsync(lesson.LessonId);
            if (existing == null)
                return false;

            await _lessonRepository.UpdateAsync(lesson);
            return true;
        }

        public async Task<bool> DeleteLessonAsync(int id)
        {
            var existing = await _lessonRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _lessonRepository.DeleteAsync(id);
            return true;
        }
    }
}
