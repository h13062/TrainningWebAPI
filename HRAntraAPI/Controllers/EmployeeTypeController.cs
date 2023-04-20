using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRAntraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeService employeeTypeService;
        public EmployeeTypeController(IEmployeeTypeService employeeTypeService)
        {
            this.employeeTypeService = employeeTypeService;
        }
        [HttpGet]
        [Route("GetAllEmployeeType")]
        public async Task<IActionResult> Get()
        {
            return Ok(await employeeTypeService.GetAllEmployeeTypes());
        }
        [HttpGet]
        [Route("GetEmployeeTypeById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var candidates = await employeeTypeService.GetEmployeeTypeByIdAsync(id);
            if (candidates == null)
            {
                return NotFound($"EmployeeType object with Id = {id} is not available");
            }
            return Ok(candidates);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeTypeRequestModel model)
        {
            var result = await employeeTypeService.AddEmployeeTypeAsync(model);
            if (result != 0)
            {
                return Ok(model);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await employeeTypeService.DeleteEmployeeTypeAsync(id);
            if (result != 0)
            {
                return Ok("Baby Deleted Successfully");
            }
            return BadRequest();
        }
    }
}
