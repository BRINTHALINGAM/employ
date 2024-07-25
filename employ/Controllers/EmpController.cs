using Bussiness.Service.services;
using Microsoft.AspNetCore.Mvc;
using employ.Models;
using DataLayer.Service.DQ;

namespace employ.Controllers
{
   [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmpService _empService;

        public EmpController(IEmpService empService)
        {
            _empService = empService;
        }

        [HttpGet]
        public IEnumerable<EmpDTO> Get() => _empService.GetAllEmployees();

       

        [HttpGet("{id}")]
        public ActionResult<EmpDTO> Get(int id)
        {
            var employee = _empService.GetEmployeeById(id);
            if (employee == null) return NotFound();
            return employee;
        }




        [HttpPost]
        public IActionResult Post([FromBody] EmpDTO employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is missing");
            }

            if (!ModelState.IsValid)
            {
                // Log the model state errors
                foreach (var state in ModelState)
                {
                    Console.WriteLine($"{state.Key}: {string.Join(", ", state.Value.Errors.Select(e => e.ErrorMessage))}");
                }

                return BadRequest(ModelState);
            }

            try
            {
                _empService.AddEmployee(employee);
                return Ok(true);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.ToString());
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmpDTO employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest("Employee ID mismatch");
            }

            if (employee.Department == null)
            {
                return BadRequest(new { errors = new { Department = new[] { "The Department field is required." } } });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Returns detailed validation errors
            }

            try
            {
                _empService.UpdateEmployee(employee);
                return Ok(true);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.ToString());
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }





        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _empService.DeleteEmployee(id);
            return NoContent();
        }
    }
}
