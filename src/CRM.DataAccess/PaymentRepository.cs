using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _dbContext.Payments
                .OrderByDescending(x => x.PaymentId)
                .ToListAsync();
        }

        public async Task<Payment?> GetByIdAsync(int id)
        {
            return await _dbContext.Payments.FindAsync(id);
        }

        public async Task AddAsync(Payment payment)
        {
            await _dbContext.Payments.AddAsync(payment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Payment payment)
        {
            _dbContext.Payments.Update(payment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var payment = await _dbContext.Payments.FindAsync(id);

            if (payment == null)
                return;

            _dbContext.Payments.Remove(payment);
            await _dbContext.SaveChangesAsync();
        }
    }
}