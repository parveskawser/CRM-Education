using CRM.Entities;

namespace CRM.Facade.Interface
{
    public interface IPaymentFacade
    {
        Task<List<Payment>> GetPaymentsAsync();
        Task<Payment?> GetPaymentByIdAsync(int id);
        Task AddPaymentAsync(Payment payment);
        Task<bool> UpdatePaymentAsync(Payment payment);
        Task<bool> DeletePaymentAsync(int id);
    }
}
