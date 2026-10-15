using CRM.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DataAccess.Interface
{
    public interface ITransactionReportRepository
    {
        Task<List<TransactionReport>> GetAllAsync();
        Task<TransactionReport?> GetByIdAsync(int id);
        Task AddAsync(TransactionReport transactionReport);
        Task UpdateAsync(TransactionReport transactionReport);
        Task DeleteAsync(int id);
    }
}