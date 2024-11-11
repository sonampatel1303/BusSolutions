using FastX_CaseStudy.Models;
using FastX_CaseStudy.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastX_CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;


        public BookingController(IBookingService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetallBookings()
        {
            var booking = _service.GetallBookings();

            return Ok(booking);
        }


        [HttpGet("{id}")]
        public IActionResult ViewBookingHistorybyId(int id)
        {
            var booking = _service.ViewBookingHistorybyId(id);
            if (booking == null)
            {
                return NotFound($"Booking with ID {id} not found.");
            }
            return Ok(booking);
        }


        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            if (booking == null)
            {
                return BadRequest("Booking data is required.");
            }

            int bookingId = _service.AddBooking(booking);
            return Ok(bookingId);
        }

        [HttpPut]
        public IActionResult UpdateBooking(Booking booking)
        {
            if (booking == null)
            {
                return BadRequest("Booking data is required.");
            }

            string result = _service.UpdateBooking(booking);
            return Ok(result);

        }
        [HttpPut("{id}")]
        public IActionResult CancelBooking(int id)
        {
            if (id == 0 || id == null)
            {
                return BadRequest("Booking data is required.");
            }
            string result = _service.CancelBooking(id);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            string result = _service.DeleteBooking(id);

            return Ok(result);

        }
    }
}
