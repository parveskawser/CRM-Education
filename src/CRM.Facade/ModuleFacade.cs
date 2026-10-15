using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade
{
    public class ModuleFacade : IModuleFacade
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleFacade(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<List<Module>> GetModulesAsync()
        {
            return await _moduleRepository.GetAllAsync();
        }

        public async Task<Module?> GetModuleByIdAsync(int id)
        {
            return await _moduleRepository.GetByIdAsync(id);
        }

        public async Task AddModuleAsync(Module module)
        {
            ArgumentNullException.ThrowIfNull(module);
            await _moduleRepository.AddAsync(module);
        }

        public async Task<bool> UpdateModuleAsync(Module module)
        {
            ArgumentNullException.ThrowIfNull(module);

            var existing = await _moduleRepository.GetByIdAsync(module.ModuleId);
            if (existing == null)
                return false;

            await _moduleRepository.UpdateAsync(module);
            return true;
        }

        public async Task<bool> DeleteModuleAsync(int id)
        {
            var existing = await _moduleRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _moduleRepository.DeleteAsync(id);
            return true;
        }
    }
}
