using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface IQuizQuestionFacade
    {
        Task<List<QuizQuestion>> GetQuizQuestionsAsync();
        Task<QuizQuestion?> GetQuizQuestionByIdAsync(int id);
        Task AddQuizQuestionAsync(QuizQuestion quizQuestion);
        Task<bool> UpdateQuizQuestionAsync(QuizQuestion quizQuestion);
        Task<bool> DeleteQuizQuestionAsync(int id);
    }
}
