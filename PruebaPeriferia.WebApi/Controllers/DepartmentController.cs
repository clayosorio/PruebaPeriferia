using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaPeriferia.Application.Dtos.Input;
using PruebaPeriferia.Application.Interfaces;

namespace PruebaPeriferia.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null) return NotFound("Department does not exist");
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] DepartmentInputDto department)
        {
            if (department == null) return BadRequest("Invalid department data");

            await _departmentService.AddDepartmentAsync(department);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentInputDto department)
        {
            if (department == null) return BadRequest("Invalid department data");

            var updated = await _departmentService.UpdateDepartmentAsync(id, department);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var deleted = await _departmentService.DeleteDepartmentAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }

        [HttpGet("{id}/employees")]
        public async Task<IActionResult> GetEmployeesByDepartment(int id)
        {
            var response = await _departmentService.GetEmployeesByDepartmentAsync(id);
            return !response.Any() ? NotFound("There is not employees on this department") : Ok(response);
        }

        [HttpGet("{id:int}/salary")]
        public async Task<IActionResult> GetDepartmentSalary(int id)
        {
            var salary = await _departmentService.GetDepartmentSalaryAsync(id);
            return Ok(new { DepartmentId = id, TotalSalary = salary });
        }
    }
}
