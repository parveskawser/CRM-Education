using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade.Implementation
{
    public class AiCourseQueryFacade : IAiCourseQueryFacade
    {
        private readonly IAiCourseQueryRepository _aiCourseQueryRepository;

        public AiCourseQueryFacade(IAiCourseQueryRepository aiCourseQueryRepository)
        {
            _aiCourseQueryRepository = aiCourseQueryRepository;
        }

        public async Task<List<AiCourseQuery>> GetAiCourseQueriesAsync()
        {
            return await _aiCourseQueryRepository.GetAllAsync();
        }

        public async Task<AiCourseQuery?> GetAiCourseQueryByIdAsync(int id)
        {
            return await _aiCourseQueryRepository.GetByIdAsync(id);
        }

        public async Task AddAiCourseQueryAsync(AiCourseQuery aiCourseQuery)
        {
            ArgumentNullException.ThrowIfNull(aiCourseQuery);
            await _aiCourseQueryRepository.AddAsync(aiCourseQuery);
        }

        public async Task<bool> UpdateAiCourseQueryAsync(AiCourseQuery aiCourseQuery)
        {
            ArgumentNullException.ThrowIfNull(aiCourseQuery);

            var existing = await _aiCourseQueryRepository.GetByIdAsync(aiCourseQuery.QueryId);
            if (existing == null)
                return false;

            await _aiCourseQueryRepository.UpdateAsync(aiCourseQuery);
            return true;
        }

        public async Task<bool> DeleteAiCourseQueryAsync(int id)
        {
            var existing = await _aiCourseQueryRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _aiCourseQueryRepository.DeleteAsync(id);
            return true;
        }
    }
}
