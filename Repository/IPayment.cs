using FastX_CaseStudy.Models;

namespace FastX_CaseStudy.Repository
{
    public interface IPayment
    {
        List<Payment> GetAllPayments();
        Payment GetPaymentById(int id);

        int AddPayment(Payment payment);
        string UpdatePayment(Payment payment);
        string DeletePayment(int id);

       
    }
}
