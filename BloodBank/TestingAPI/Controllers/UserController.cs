using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository.DatabaseContext;
using Repository.Interfaces;

namespace BolnicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public UserController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _repository.User.GetAllUsersAsync());
        }
        [HttpGet("GetSingleUser")]
        public async Task<IActionResult> GetSingleUser(int Id)
        {
            return Ok(await _repository.User.GetUser(user => user.Id == Id));
        }
    }
}
