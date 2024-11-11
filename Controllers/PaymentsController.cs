using FastX_CaseStudy.Models;
using FastX_CaseStudy.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastX_CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPayment _payment;

        public PaymentsController(IPayment payment)
        {
            _payment = payment;
        }

        [HttpGet]
        public IActionResult GetAllPayments() { 

        var payments=_payment.GetAllPayments();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public IActionResult ViewPaymentbyId(int id)
        {
            var payments = _payment.GetPaymentById(id);
            if (payments== null)
            {
                return NotFound($"Payment with ID {id} not found.");
            }
            return Ok(payments);
        }

        [HttpPost]
        public IActionResult AddPayment(Payment payments)
        {
            if (payments == null)
            {
                return BadRequest("Payment data is required.");
            }

            int payId = _payment.AddPayment(payments);
            return Ok(payId);
        }

        [HttpPut]
        public IActionResult UpdatePayment(Payment payments)
        {
            if (payments == null)
            {
                return BadRequest("Booking data is required.");
            }

            string result = _payment.UpdatePayment(payments);
            return Ok(result);

        }
        [HttpDelete]
        public IActionResult DeletePayment(int id)
        {
            string result = _payment.DeletePayment(id);

            return Ok(result);

        }

    }
}
