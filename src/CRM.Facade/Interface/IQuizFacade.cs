using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface IQuizFacade
    {
        Task<List<Quiz>> GetQuizzesAsync();
        Task<Quiz?> GetQuizByIdAsync(int id);
        Task AddQuizAsync(Quiz quiz);
        Task<bool> UpdateQuizAsync(Quiz quiz);
        Task<bool> DeleteQuizAsync(int id);
    }
}
