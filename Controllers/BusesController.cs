using FastX_CaseStudy.Models;
using FastX_CaseStudy.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FastX_CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        private readonly IBusService _service;
        public BusesController(IBusService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllBuses()
        {
            List<bus> buses = _service.GetAllBuses();
            return Ok(buses);
        }

        [HttpGet("{id}")]
        public IActionResult GetBusById(int id)
        {
            bus buses = _service.GetBusById(id);
            return Ok(buses);
        }
        [HttpPost]
        public IActionResult Post(bus buses)
        {
            int Result = _service.AddNewBus(buses);
            return Ok(Result);
        }
        [HttpPut]
        public IActionResult Put(bus buses)
        {
            string result = _service.UpdateBus(buses);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            string result = _service.DeleteBus(id);
            return Ok(result);
        }

    }
}
