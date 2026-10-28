using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Account>> GetAllAsync()
        {
            return await _dbContext.Accounts
                .OrderByDescending(x => x.UserId)
                .ToListAsync();
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            return await _dbContext.Accounts.FindAsync(id);
        }

        public async Task AddAsync(Account account)
        {
            await _dbContext.Accounts.AddAsync(account);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account account)
        {
            _dbContext.Accounts.Update(account);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var account = await _dbContext.Accounts.FindAsync(id);

            if (account == null)
                return;

            _dbContext.Accounts.Remove(account);
            await _dbContext.SaveChangesAsync();
        }
    }
}