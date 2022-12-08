using BusinessLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegUserController : ControllerBase
    {
        private readonly IRegUsersService _regUsersService;
        private readonly IUsersService _usersService;

        public RegUserController(IRegUsersService regUsersService, IUsersService usersService)
        {
            _regUsersService = regUsersService;
            _usersService = usersService;
        }
        [HttpGet("GetAllRegUsers")]
        public async Task<IActionResult> GetRegUsers()
        {
            return Ok(await _regUsersService.GetAll());
        }
        [HttpGet("GetSingleRegUser")]
        public async Task<IActionResult> GetSingleRegUser(int Id)
        {
            return Ok(await _regUsersService.Get(regUser => regUser.Id == Id));
        }
        [HttpDelete("DeleteRegUser")]
        public async Task<IActionResult> DeleteRegUser(int Id)
        {
            var regUser = await _regUsersService.Get(ru => ru.Id == Id);
            await _regUsersService.Delete(regUser);
            return Ok(regUser);
        }
        [HttpPut("UpdateRegUser")]
        public async Task<IActionResult> UpdateRegUser(RegUserUpdateDto update)
        {
            var regUser = new RegUser
            {
                Id = update.Id,
                UserID = update.UserId,
                FirstName = update.Name,
                LastName = update.LastName,
                Age = update.Age,
                Address = update.Address,
                PhoneNumber = update.Phone
            };
            await _regUsersService.Update(regUser);
            return Ok(regUser);
        }
    }
}
