using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade
{
    public class QuizAttemptFacade : IQuizAttemptFacade
    {
        private readonly IQuizAttemptRepository _quizAttemptRepository;

        public QuizAttemptFacade(IQuizAttemptRepository quizAttemptRepository)
        {
            _quizAttemptRepository = quizAttemptRepository;
        }

        public async Task<List<QuizAttempt>> GetQuizAttemptsAsync()
        {
            return await _quizAttemptRepository.GetAllAsync();
        }

        public async Task<QuizAttempt?> GetQuizAttemptByIdAsync(int id)
        {
            return await _quizAttemptRepository.GetByIdAsync(id);
        }

        public async Task AddQuizAttemptAsync(QuizAttempt quizAttempt)
        {
            ArgumentNullException.ThrowIfNull(quizAttempt);
            await _quizAttemptRepository.AddAsync(quizAttempt);
        }

        public async Task<bool> UpdateQuizAttemptAsync(QuizAttempt quizAttempt)
        {
            ArgumentNullException.ThrowIfNull(quizAttempt);

            var existing = await _quizAttemptRepository.GetByIdAsync(quizAttempt.AttemptId);
            if (existing == null)
                return false;

            await _quizAttemptRepository.UpdateAsync(quizAttempt);
            return true;
        }

        public async Task<bool> DeleteQuizAttemptAsync(int id)
        {
            var existing = await _quizAttemptRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _quizAttemptRepository.DeleteAsync(id);
            return true;
        }
    }
}
