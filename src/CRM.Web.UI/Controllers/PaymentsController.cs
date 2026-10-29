
using CRM.Entities;
using CRM.Facade.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.UI.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IPaymentFacade _paymentFacade;

        public PaymentsController(IPaymentFacade paymentFacade)
        {
            _paymentFacade = paymentFacade;
        }

        private void LoadPaymentOptions()
        {
            ViewBag.PaymentMethods = new List<string>
            {
                "CreditCard",
                "DebitCard",
                "Cash",
                "BankTransfer",
                "MobileBanking"
            };

            ViewBag.PaymentStatuses = new List<string>
            {
                "Pending",
                "Completed",
                "Failed",
                "Refunded"
            };
        }

        // GET: /Payments
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var payments = await _paymentFacade.GetPaymentsAsync();
            return View(payments);
        }

        // GET: /Payments/Detail/1
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var payment = await _paymentFacade.GetPaymentByIdAsync(id);

            if (payment == null)
                return NotFound();

            return View(payment);
        }

        // GET: /Payments/AddPayment
        [HttpGet]
        public IActionResult AddPayment()
        {
            LoadPaymentOptions();

            return View(new Payment());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPayment(Payment payment)
        {
            LoadPaymentOptions();


            try
            {
                payment.PaidAt = DateTime.UtcNow;

                await _paymentFacade.AddPaymentAsync(payment);

                TempData["Success"] = "Payment saved successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var error = ex.InnerException?.Message ?? ex.Message;

                ModelState.AddModelError(
                    string.Empty,
                    "Database save failed: " + error
                );

                return View(payment);
            }
        }

        // GET: /Payments/EditPayment/1
        [HttpGet]
        public async Task<IActionResult> EditPayment(int id)
        {
            var payment = await _paymentFacade.GetPaymentByIdAsync(id);

            if (payment == null)
                return NotFound();

            LoadPaymentOptions();

            return View(payment);
        }

        // POST: /Payments/EditPayment
        [HttpPost]
        public async Task<IActionResult> EditPayment(Payment payment)
        {
            if (payment.EnrollmentId <= 0)
            {
                ModelState.AddModelError(
                    nameof(payment.EnrollmentId),
                    "Enter a valid Enrollment ID."
                );
            }

            

            var methods = new[]
            {
                "CreditCard", "DebitCard", "Cash",
                "BankTransfer", "MobileBanking"
            };

            var statuses = new[]
            {
                "Pending", "Completed", "Failed", "Refunded"
            };


            try
            {
                var existing = await _paymentFacade
                    .GetPaymentByIdAsync(payment.PaymentId);

                if (existing == null)
                    return NotFound();

                existing.EnrollmentId = payment.EnrollmentId;
                existing.Amount = payment.Amount;
                existing.PaymentMethod = payment.PaymentMethod;
                existing.PaymentStatus = payment.PaymentStatus;
                existing.TransactionId = payment.TransactionId;

                // Preserve the original payment date.
                await _paymentFacade.UpdatePaymentAsync(existing);

                TempData["Success"] = "Payment updated successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError(
                    "",
                    "Unable to update the payment. Check the Enrollment ID and try again."
                );

                LoadPaymentOptions();
                return View(payment);
            }
        }

        // GET: /Payments/Delete/1
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var payment = await _paymentFacade.GetPaymentByIdAsync(id);

            if (payment == null)
                return NotFound();

            return View(payment);
        }

        // POST: /Payments/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Payment payment)
        {
            var result = await _paymentFacade
                .DeletePaymentAsync(payment.PaymentId);

            if (result)
            {
                TempData["Success"] = "Payment deleted successfully.";
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}
