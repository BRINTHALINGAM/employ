using Bussiness.Service.services;
using Microsoft.AspNetCore.Mvc;
using employ.Models;
using DataLayer.Service.DQ;

namespace employ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptController : ControllerBase
    {
        private readonly IDeptService _deptService;

        public DeptController(IDeptService deptService)
        {
            _deptService = deptService;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _deptService.GetAllDepartments(); // This should return a list of Department objects
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public ActionResult<DeptDTO> Get(int id)
        {
            var department = _deptService.GetDepartmentById(id);
            if (department == null) return NotFound();
            return department;
        }

        [HttpPost]
        public IActionResult CreateDepartment([FromBody] DeptDTO department)
        {
            if (department == null)
            {
                return BadRequest("Department data is missing");
            }

            department.CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow);

            _deptService.AddDepartment(department);
            return CreatedAtAction(nameof(GetDepartments), new { id = department.DepartmentId }, department);
        }


        [HttpPut("{id}")]
           public IActionResult Put(int id, [FromBody] DeptDTO department)
         {
           if (id != department.DepartmentId) return BadRequest();
          _deptService.UpdateDepartment(department);
           return NoContent();
         }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _deptService.DeleteDepartment(id);
            return NoContent();
        }
    }
}
