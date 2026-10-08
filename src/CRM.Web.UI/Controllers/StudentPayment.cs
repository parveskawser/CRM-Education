using CRM.Entities;

namespace CRM.Web.UI.Controllers
{
    internal class StudentPayment
    {
        public StudentPayment()
        {
        }

        public List<Payment> PaymentList { get; internal set; }
        public Students Student { get; internal set; }
    }
}