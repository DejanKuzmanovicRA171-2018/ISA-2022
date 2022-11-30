using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegUserController : ControllerBase
    {
        private readonly IRegUsersService _regUserService;

        public RegUserController(IRepositoryWrapper repository, IRegUsersService regUsersService)
        {
            _regUserService = regUsersService;
        }
        [HttpGet("GetAllRegUsers")]
        public async Task<IActionResult> GetRegUsers()
        {
            return Ok(await _regUserService.GetAll());
        }
        [HttpGet("GetSingleRegUser")]
        public async Task<IActionResult> GetSingleRegUser(int Id)
        {
            return Ok(await _regUserService.Get(regUser => regUser.Id == Id));
        }
    }
}
