using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade.Implementation
{
    public class LiveClassFacade : ILiveClassFacade
    {
        private readonly ILiveClassRepository _liveClassRepository;

        public LiveClassFacade(ILiveClassRepository liveClassRepository)
        {
            _liveClassRepository = liveClassRepository;
        }

        public async Task<List<LiveClass>> GetLiveClassesAsync()
        {
            return await _liveClassRepository.GetAllAsync();
        }

        public async Task<LiveClass?> GetLiveClassByIdAsync(int id)
        {
            return await _liveClassRepository.GetByIdAsync(id);
        }

        public async Task AddLiveClassAsync(LiveClass liveClass)
        {
            ArgumentNullException.ThrowIfNull(liveClass);
            await _liveClassRepository.AddAsync(liveClass);
        }

        public async Task<bool> UpdateLiveClassAsync(LiveClass liveClass)
        {
            ArgumentNullException.ThrowIfNull(liveClass);

            var existing = await _liveClassRepository.GetByIdAsync(liveClass.LiveClassId);
            if (existing == null)
                return false;

            await _liveClassRepository.UpdateAsync(liveClass);
            return true;
        }

        public async Task<bool> DeleteLiveClassAsync(int id)
        {
            var existing = await _liveClassRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _liveClassRepository.DeleteAsync(id);
            return true;
        }
    }
}
