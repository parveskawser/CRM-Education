using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface IModuleFacade
    {
        Task<List<Module>> GetModulesAsync();
        Task<Module?> GetModuleByIdAsync(int id);
        Task AddModuleAsync(Module module);
        Task<bool> UpdateModuleAsync(Module module);
        Task<bool> DeleteModuleAsync(int id);
    }
}
