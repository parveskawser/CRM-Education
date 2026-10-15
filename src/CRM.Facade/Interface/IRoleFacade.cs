using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface IRoleFacade
    {
        Task<List<Role>> GetRolesAsync();
        Task<Role?> GetRoleByIdAsync(int id);
        Task AddRoleAsync(Role role);
        Task<bool> UpdateRoleAsync(Role role);
        Task<bool> DeleteRoleAsync(int id);
    }
}
