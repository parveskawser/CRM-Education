using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade.Implementation
{
    public class QuizFacade : IQuizFacade
    {
        private readonly IQuizRepository _quizRepository;

        public QuizFacade(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<List<Quiz>> GetQuizzesAsync()
        {
            return await _quizRepository.GetAllAsync();
        }

        public async Task<Quiz?> GetQuizByIdAsync(int id)
        {
            return await _quizRepository.GetByIdAsync(id);
        }

        public async Task AddQuizAsync(Quiz quiz)
        {
            ArgumentNullException.ThrowIfNull(quiz);
            await _quizRepository.AddAsync(quiz);
        }

        public async Task<bool> UpdateQuizAsync(Quiz quiz)
        {
            ArgumentNullException.ThrowIfNull(quiz);

            var existing = await _quizRepository.GetByIdAsync(quiz.QuizId);
            if (existing == null)
                return false;

            await _quizRepository.UpdateAsync(quiz);
            return true;
        }

        public async Task<bool> DeleteQuizAsync(int id)
        {
            var existing = await _quizRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _quizRepository.DeleteAsync(id);
            return true;
        }
    }
}
