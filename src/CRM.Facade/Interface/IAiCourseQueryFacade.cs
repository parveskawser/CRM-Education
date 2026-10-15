using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface IAiCourseQueryFacade
    {
        Task<List<AiCourseQuery>> GetAiCourseQueriesAsync();
        Task<AiCourseQuery?> GetAiCourseQueryByIdAsync(int id);
        Task AddAiCourseQueryAsync(AiCourseQuery aiCourseQuery);
        Task<bool> UpdateAiCourseQueryAsync(AiCourseQuery aiCourseQuery);
        Task<bool> DeleteAiCourseQueryAsync(int id);
    }
}
