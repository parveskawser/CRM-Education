using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface IBatchFacade
    {
        Task<List<Batch>> GetBatchesAsync();
        Task<Batch?> GetBatchByIdAsync(int id);
        Task AddBatchAsync(Batch batch);
        Task<bool> UpdateBatchAsync(Batch batch);
        Task<bool> DeleteBatchAsync(int id);
    }
}
