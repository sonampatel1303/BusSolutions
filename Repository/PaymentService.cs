using FastX_CaseStudy.Exceptions;
using FastX_CaseStudy.Models;

namespace FastX_CaseStudy.Repository
{
    public class PaymentService : IPayment
    {
        private readonly BusBookingContext _context;
        public PaymentService(BusBookingContext context)
        {
            _context = context;
        }
        public int AddPayment(Payment payment)
        {
            try
            {
                if (payment == null || payment.PaymentAmount <= 0)
                {
                    throw new InvalidPaymentException("Payment is invalid! Amount should be greater than zero");
                }
                _context.Payments.Add(payment);
                _context.SaveChanges();
                return payment.Id;
            }
            catch (InvalidPaymentException ex)
            {
                throw new InvalidPaymentException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while processing payment");
            }

        }

        public string DeletePayment(int id)
        {
            if (id != null)
            {
                var payments = _context.Payments.FirstOrDefault(x => x.Id == id);
                if (payments != null)
                {
                    _context.Payments.Remove(payments);
                    _context.SaveChanges();
                    return "the given Payment id " + id + "Removed";
                }
                else
                    return "Something went wrong with deletion";
            }

            
            return "Id should not be null or zero";
        }

        public List<Payment> GetAllPayments()
        {
            var payments = _context.Payments.ToList();
            if (payments.Count > 0)
            {
                return payments;
            }
            else
                return null;
        }

        public Payment GetPaymentById(int id)
        {
            if (id != 0 || id != null)
            {
                var payments = _context.Payments.FirstOrDefault(x => x.Id == id);
                if (payments != null)
                    return payments;
                else
                    return null;
            }
            return null;
        }

       

        public string UpdatePayment(Payment payment)
        {
          var existingPay= _context.Payments.FirstOrDefault(y => y.Id == payment.Id);
            if (existingPay != null)
            {
                existingPay.Id = payment.Id;
                existingPay.PaymentMode = payment.PaymentMode;
                existingPay.Status = payment.Status;
                existingPay.PaymentAmount = payment.PaymentAmount;
                existingPay.BookingId = payment.BookingId;
                existingPay.PaymentDate = payment.PaymentDate;
                _context.Entry(existingPay).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return "Record updated successfully";
            }
            else
            {
                return "Something went wrong";
            }
        }


      
    }
}


