using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade.Implementation
{
    public class TransactionReportFacade : ITransactionReportFacade
    {
        private readonly ITransactionReportRepository _transactionReportRepository;

        public TransactionReportFacade(ITransactionReportRepository transactionReportRepository)
        {
            _transactionReportRepository = transactionReportRepository;
        }

        public async Task<List<TransactionReport>> GetTransactionReportsAsync()
        {
            return await _transactionReportRepository.GetAllAsync();
        }

        public async Task<TransactionReport?> GetTransactionReportByIdAsync(int id)
        {
            return await _transactionReportRepository.GetByIdAsync(id);
        }

        public async Task AddTransactionReportAsync(TransactionReport transactionReport)
        {
            ArgumentNullException.ThrowIfNull(transactionReport);
            await _transactionReportRepository.AddAsync(transactionReport);
        }

        public async Task<bool> UpdateTransactionReportAsync(TransactionReport transactionReport)
        {
            ArgumentNullException.ThrowIfNull(transactionReport);

            var existing = await _transactionReportRepository.GetByIdAsync(transactionReport.ReportId);
            if (existing == null)
                return false;

            await _transactionReportRepository.UpdateAsync(transactionReport);
            return true;
        }

        public async Task<bool> DeleteTransactionReportAsync(int id)
        {
            var existing = await _transactionReportRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _transactionReportRepository.DeleteAsync(id);
            return true;
        }
    }
}
