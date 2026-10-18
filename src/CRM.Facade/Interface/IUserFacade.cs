using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface IUserFacade
    {
        Task<List<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);

        Task<User?> GetUserByEmailPasswordAsync(string email, string password);
    }
}
