using CRM.DataAccess.Interface;
using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRM.DataAccess.Implementation
{
    public class TransactionReportRepository : ITransactionReportRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionReportRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TransactionReport>> GetAllAsync()
        {
            return await _dbContext.TransactionReports
                .OrderByDescending(x => x.ReportId)
                .ToListAsync();
        }

        public async Task<TransactionReport?> GetByIdAsync(int id)
        {
            return await _dbContext.TransactionReports.FindAsync(id);
        }

        public async Task AddAsync(TransactionReport transactionReport)
        {
            await _dbContext.TransactionReports.AddAsync(transactionReport);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TransactionReport transactionReport)
        {
            _dbContext.TransactionReports.Update(transactionReport);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var transactionReport = await _dbContext.TransactionReports.FindAsync(id);

            if (transactionReport == null)
                return;

            _dbContext.TransactionReports.Remove(transactionReport);
            await _dbContext.SaveChangesAsync();
        }
    }
}