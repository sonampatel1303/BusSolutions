using FastX_CaseStudy.Exceptions;
using FastX_CaseStudy.Models;
using FastX_CaseStudy.Repository;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public IActionResult GetAllPayments() { 

        var payments=_payment.GetAllPayments();
            return Ok(payments);
        }

        [Authorize(Roles = "User")]
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

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult AddPayment(Payment payments)
        {
            if (payments == null)
            {
                return BadRequest("Payment data is required.");
            }
            try
            {
                int payId = _payment.AddPayment(payments);
                return Ok(payId);
            }
            catch (InvalidPaymentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, " " + ex.Message);
            }
        }

        [Authorize(Roles = "Admin,User")]
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

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult DeletePayment(int id)
        {
            string result = _payment.DeletePayment(id);

            return Ok(result);

        }

    }
}
