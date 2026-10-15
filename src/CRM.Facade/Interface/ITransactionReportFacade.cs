using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface ITransactionReportFacade
    {
        Task<List<TransactionReport>> GetTransactionReportsAsync();
        Task<TransactionReport?> GetTransactionReportByIdAsync(int id);
        Task AddTransactionReportAsync(TransactionReport transactionReport);
        Task<bool> UpdateTransactionReportAsync(TransactionReport transactionReport);
        Task<bool> DeleteTransactionReportAsync(int id);
    }
}
