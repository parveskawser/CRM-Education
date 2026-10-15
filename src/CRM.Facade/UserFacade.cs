using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade
{
    public class UserFacade : IUserFacade
    {
        private readonly IUserRepository _userRepository;

        public UserFacade(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            ArgumentNullException.ThrowIfNull(user);
            await _userRepository.AddAsync(user);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            ArgumentNullException.ThrowIfNull(user);

            var existing = await _userRepository.GetByIdAsync(user.UserId);
            if (existing == null)
                return false;

            await _userRepository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _userRepository.DeleteAsync(id);
            return true;
        }
    }
}
