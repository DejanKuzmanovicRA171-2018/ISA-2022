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
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _repository.User.GetAllUsersAsync());
        }
 
    }
}
