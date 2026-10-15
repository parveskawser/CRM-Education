using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface ILiveClassFacade
    {
        Task<List<LiveClass>> GetLiveClassesAsync();
        Task<LiveClass?> GetLiveClassByIdAsync(int id);
        Task AddLiveClassAsync(LiveClass liveClass);
        Task<bool> UpdateLiveClassAsync(LiveClass liveClass);
        Task<bool> DeleteLiveClassAsync(int id);
    }
}
