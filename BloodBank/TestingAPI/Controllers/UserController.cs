using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace BolnicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IUsersService _usersService;

        public UserController(IRepositoryWrapper repository, IUsersService usersService)
        {
            _repository = repository;
            _usersService = usersService;
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _usersService.GetAll());
        }
        [HttpGet("GetSingleUser")]
        public async Task<IActionResult> GetSingleUser(string Id)
        {
            return Ok(await _usersService.GetUser(Id));
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string Email)
        {
            var user = new IdentityUser { Email = Email };
            await _usersService.Delete(user);
            return Ok(user);
        }
    }
}
