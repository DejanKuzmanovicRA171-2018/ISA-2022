using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminsService _adminsService;
        private readonly IUsersService _usersService;

        public AdminController(IAdminsService adminsService, IUsersService usersService)
        {
            _adminsService = adminsService;
            _usersService = usersService;
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
        [HttpDelete("DeleteAdmin")]
        public async Task<IActionResult> DeleteAdmin(int Id)
        {
            var admin = await _adminsService.Get(admin => admin.Id == Id);
            // var user = await _usersService.Get(user => user.Id == admin.UserId);
            await _adminsService.Delete(admin);
            // await _usersService.Delete(user);
            return Ok(admin);
        }
    }
}
