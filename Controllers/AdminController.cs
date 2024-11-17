using FastX_CaseStudy.Models;
using FastX_CaseStudy.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace FastX_CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   [Authorize(Roles ="Admin")]

    public class AdminController : ControllerBase
    {
        private readonly IAdmin _service;

        public AdminController(IAdmin service)
        {
            _service = service;
        }

        // Users
      
        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            List<User> users = _service.GetAllUsers();
            return Ok(users);
        }
       
        [HttpGet("users/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _service.GetUserDetails(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(user);
        }

      
        [HttpPost("users")]
        public IActionResult PostUser(User user)
        {
            int result = _service.AddUser(user);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("users/{userid}")]
        public IActionResult PutUser(int userid, User user)
        {
            string result = _service.UpdateUser(userid, user);
            return Ok(result);
        }

        
        [HttpDelete("users/{id}")]
        public IActionResult DeleteUser(int id)
        {
            string result = _service.DeleteUser(id);
            return Ok(result);
        }

        // Operators
        
        [HttpGet("operators")]
        public IActionResult GetAllOperators()
        {
            List<BusOperator> operators = _service.GetAllOperators();
            return Ok(operators);
        }

        
        [HttpGet("operators/{id}")]
        public IActionResult GetOperatorById(int id)
        {
            var operatorDetails = _service.GetOperatorDetails(id);
            if (operatorDetails == null)
            {
                return NotFound($"Operator with ID {id} not found.");
            }
            return Ok(operatorDetails);
        }

      
        [HttpPost("operators")]
        public IActionResult PostOperator(BusOperator busOperator)
        {
            int result = _service.AddOperator(busOperator);
            return Ok(result);
        }

      
        [HttpPut("operators/{opid}")]
        public IActionResult PutOperator(int opid, BusOperator busOperator)
        {
            string result = _service.UpdateOperator(opid, busOperator);
            return Ok(result);
        }

      
        [HttpDelete("operators/{id}")]
        public IActionResult DeleteOperator(int id)
        {
            string result = _service.DeleteOperator(id);
            return Ok(result);
        }

        //admin
      
        [HttpGet("admin")]
        public IActionResult AdminDetails() {
            List<User> admins = _service.DisplayAdmin();
            return Ok(admins);
        }
    }
}
