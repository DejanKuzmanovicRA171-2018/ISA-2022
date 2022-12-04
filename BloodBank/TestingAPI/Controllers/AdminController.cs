using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminsService _adminsService;

        public AdminController(IAdminsService adminsService)
        {
            _adminsService = adminsService;
        }
        [HttpGet("GetAllAdmins")]
        public async Task<IActionResult> GetAdmins()
        {
            return Ok(await _adminsService.GetAll());
        }
        [HttpGet("GetSingleAdmin")]
        public async Task<IActionResult> GetSingleAdmin(int Id)
        {
            return Ok(await _adminsService.Get(admin => admin.Id == Id));
        }
    }
}
