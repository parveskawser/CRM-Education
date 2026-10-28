using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade.Implementation
{
    public class AccountFacade : IAccountFacade
    {
        private readonly IAccountRepository _accountRepository;

        public AccountFacade(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            return await _accountRepository.GetAllAsync();
        }

        public async Task<Account?> GetAccountByIdAsync(int id)
        {
            return await _accountRepository.GetByIdAsync(id);
        }

        public async Task AddAccountAsync(Account account)
        {
            ArgumentNullException.ThrowIfNull(account);
            await _accountRepository.AddAsync(account);
        }

        public async Task<bool> UpdateAccountAsync(Account account)
        {
            ArgumentNullException.ThrowIfNull(account);

            var existing = await _accountRepository.GetByIdAsync(account.UserId);
            if (existing == null)
                return false;

            await _accountRepository.UpdateAsync(account);
            return true;
        }

        public async Task<bool> DeleteAccountAsync(int id)
        {
            var existing = await _accountRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _accountRepository.DeleteAsync(id);
            return true;
        }
    }
}
