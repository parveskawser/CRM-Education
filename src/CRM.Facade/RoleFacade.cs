using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade
{
    public class RoleFacade : IRoleFacade
    {
        private readonly IRoleRepository _roleRepository;

        public RoleFacade(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        public async Task<Role?> GetRoleByIdAsync(int id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

        public async Task AddRoleAsync(Role role)
        {
            ArgumentNullException.ThrowIfNull(role);
            await _roleRepository.AddAsync(role);
        }

        public async Task<bool> UpdateRoleAsync(Role role)
        {
            ArgumentNullException.ThrowIfNull(role);

            var existing = await _roleRepository.GetByIdAsync(role.RoleId);
            if (existing == null)
                return false;

            await _roleRepository.UpdateAsync(role);
            return true;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var existing = await _roleRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _roleRepository.DeleteAsync(id);
            return true;
        }
    }
}
