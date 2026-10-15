using CRM.DataAccess.Interface;
using CRM.Entities;
using CRM.Facade.Interface;

namespace CRM.Facade
{
    public class PaymentFacade : IPaymentFacade
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentFacade(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<List<Payment>> GetPaymentsAsync()
        {
            return await _paymentRepository.GetAllAsync();
        }

        public async Task<Payment?> GetPaymentByIdAsync(int id)
        {
            return await _paymentRepository.GetByIdAsync(id);
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            ArgumentNullException.ThrowIfNull(payment);
            await _paymentRepository.AddAsync(payment);
        }

        public async Task<bool> UpdatePaymentAsync(Payment payment)
        {
            ArgumentNullException.ThrowIfNull(payment);

            var existing = await _paymentRepository.GetByIdAsync(payment.PaymentId);
            if (existing == null)
                return false;

            await _paymentRepository.UpdateAsync(payment);
            return true;
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            var existing = await _paymentRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _paymentRepository.DeleteAsync(id);
            return true;
        }
    }
}
