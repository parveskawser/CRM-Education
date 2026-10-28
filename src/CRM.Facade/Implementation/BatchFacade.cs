using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade.Implementation
{
    public class BatchFacade : IBatchFacade
    {
        private readonly IBatchRepository _batchRepository;

        public BatchFacade(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }

        public async Task<List<Batch>> GetBatchesAsync()
        {
            return await _batchRepository.GetAllAsync();
        }

        public async Task<Batch?> GetBatchByIdAsync(int id)
        {
            return await _batchRepository.GetByIdAsync(id);
        }

        public async Task AddBatchAsync(Batch batch)
        {
            ArgumentNullException.ThrowIfNull(batch);
            await _batchRepository.AddAsync(batch);
        }

        public async Task<bool> UpdateBatchAsync(Batch batch)
        {
            ArgumentNullException.ThrowIfNull(batch);

            var existing = await _batchRepository.GetByIdAsync(batch.BatchId);
            if (existing == null)
                return false;

            await _batchRepository.UpdateAsync(batch);
            return true;
        }

        public async Task<bool> DeleteBatchAsync(int id)
        {
            var existing = await _batchRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _batchRepository.DeleteAsync(id);
            return true;
        }
    }
}
