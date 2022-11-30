using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;

        public EmployeeController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }
        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _employeesService.GetAll());
        }
        [HttpGet("GetSingleEmployee")]
        public async Task<IActionResult> GetSingleEmployee(int Id)
        {
            return Ok(await _employeesService.Get(employee => employee.Id == Id));
        }
    }
}
