using BusinessLogic;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly IUsersService _usersService;
        private readonly UserManager<IdentityUser> _userManager;


        public EmployeeController(IEmployeesService employeesService, IUsersService usersService, UserManager<IdentityUser> userManager)
        {
            _employeesService = employeesService;
            _usersService = usersService;
            _userManager = userManager;
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
        [HttpGet("GetSingleEmployeeByEmail")]
        public async Task<IActionResult> GetSingleEmployeeByEmail(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            return Ok(await _employeesService.Get(employee => employee.UserId == user.Id));
        }
        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            var employee = await _employeesService.Get(em => em.Id == Id);
            await _employeesService.Delete(employee);
            return Ok(employee);
        }
    }
}
