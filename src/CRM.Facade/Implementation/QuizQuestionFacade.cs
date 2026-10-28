using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade.Implementation
{
    public class QuizQuestionFacade : IQuizQuestionFacade
    {
        private readonly IQuizQuestionRepository _quizQuestionRepository;

        public QuizQuestionFacade(IQuizQuestionRepository quizQuestionRepository)
        {
            _quizQuestionRepository = quizQuestionRepository;
        }

        public async Task<List<QuizQuestion>> GetQuizQuestionsAsync()
        {
            return await _quizQuestionRepository.GetAllAsync();
        }

        public async Task<QuizQuestion?> GetQuizQuestionByIdAsync(int id)
        {
            return await _quizQuestionRepository.GetByIdAsync(id);
        }

        public async Task AddQuizQuestionAsync(QuizQuestion quizQuestion)
        {
            ArgumentNullException.ThrowIfNull(quizQuestion);
            await _quizQuestionRepository.AddAsync(quizQuestion);
        }

        public async Task<bool> UpdateQuizQuestionAsync(QuizQuestion quizQuestion)
        {
            ArgumentNullException.ThrowIfNull(quizQuestion);

            var existing = await _quizQuestionRepository.GetByIdAsync(quizQuestion.QuestionId);
            if (existing == null)
                return false;

            await _quizQuestionRepository.UpdateAsync(quizQuestion);
            return true;
        }

        public async Task<bool> DeleteQuizQuestionAsync(int id)
        {
            var existing = await _quizQuestionRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _quizQuestionRepository.DeleteAsync(id);
            return true;
        }
    }
}
