using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade.Implementation
{
    public class LessonProgressFacade : ILessonProgressFacade
    {
        private readonly ILessonProgressRepository _lessonProgressRepository;

        public LessonProgressFacade(ILessonProgressRepository lessonProgressRepository)
        {
            _lessonProgressRepository = lessonProgressRepository;
        }

        public async Task<List<LessonProgress>> GetLessonProgressesAsync()
        {
            return await _lessonProgressRepository.GetAllAsync();
        }

        public async Task<LessonProgress?> GetLessonProgressByIdAsync(int id)
        {
            return await _lessonProgressRepository.GetByIdAsync(id);
        }

        public async Task AddLessonProgressAsync(LessonProgress lessonProgress)
        {
            ArgumentNullException.ThrowIfNull(lessonProgress);
            await _lessonProgressRepository.AddAsync(lessonProgress);
        }

        public async Task<bool> UpdateLessonProgressAsync(LessonProgress lessonProgress)
        {
            ArgumentNullException.ThrowIfNull(lessonProgress);

            var existing = await _lessonProgressRepository.GetByIdAsync(lessonProgress.ProgressId);
            if (existing == null)
                return false;

            await _lessonProgressRepository.UpdateAsync(lessonProgress);
            return true;
        }

        public async Task<bool> DeleteLessonProgressAsync(int id)
        {
            var existing = await _lessonProgressRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _lessonProgressRepository.DeleteAsync(id);
            return true;
        }
    }
}
