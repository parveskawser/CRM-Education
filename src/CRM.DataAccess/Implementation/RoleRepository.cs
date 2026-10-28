using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RoleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _dbContext.Roles
                .OrderByDescending(x => x.RoleId)
                .ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await _dbContext.Roles.FindAsync(id);
        }

        public async Task AddAsync(Role role)
        {
            await _dbContext.Roles.AddAsync(role);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            _dbContext.Roles.Update(role);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var role = await _dbContext.Roles.FindAsync(id);

            if (role == null)
                return;

            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();
        }
    }
}