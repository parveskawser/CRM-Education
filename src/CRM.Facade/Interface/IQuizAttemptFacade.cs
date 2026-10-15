using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface IQuizAttemptFacade
    {
        Task<List<QuizAttempt>> GetQuizAttemptsAsync();
        Task<QuizAttempt?> GetQuizAttemptByIdAsync(int id);
        Task AddQuizAttemptAsync(QuizAttempt quizAttempt);
        Task<bool> UpdateQuizAttemptAsync(QuizAttempt quizAttempt);
        Task<bool> DeleteQuizAttemptAsync(int id);
    }
}
