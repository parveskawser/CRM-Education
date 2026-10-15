using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface IAccountFacade
    {
        Task<List<Account>> GetAccountsAsync();
        Task<Account?> GetAccountByIdAsync(int id);
        Task AddAccountAsync(Account account);
        Task<bool> UpdateAccountAsync(Account account);
        Task<bool> DeleteAccountAsync(int id);
    }
}
