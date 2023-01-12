using BusinessLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;

        public RegUserController(IRegUsersService regUsersService, IUsersService usersService, UserManager<IdentityUser> userManager)
        {
            _regUsersService = regUsersService;
            _usersService = usersService;
            _userManager = userManager;
        }
        [HttpGet("GetAllRegUsers")]
        public async Task<IActionResult> GetRegUsers()
        {
            return Ok(await _regUsersService.GetAll());
        }
        [HttpGet("GetSingleRegUserByEmail")]
        public async Task<IActionResult> GetSingleRegUserByEmail(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            return Ok(await _regUsersService.Get(regUser => regUser.UserID == user.Id));
        }
        [HttpGet("GetSingleRegUser")]
        public async Task<IActionResult> GetSingleRegUser(int Id)
        {
            return Ok(await _regUsersService.Get(regUser => regUser.Id == Id));
        }
        [HttpGet("GetEligibleForDonation")]
        public async Task<IActionResult> GetEligibleForDonation(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            var regUser = await _regUsersService.Get(regUser => regUser.UserID == user.Id);
            var span = DateTime.UtcNow.Subtract(regUser.LastBloodDonation);
            if (span.TotalHours >= 4380)
                return Ok(true);
            return Ok(false);
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
                Address = update.Address,
                PhoneNumber = update.Phone,
                Country = update.Country,
                City = update.City,
                Career = update.Career,
                CompanyName = update.CompanyName,
                BirthDate = update.BirthDate,
            };
            await _regUsersService.Update(regUser);
            return Ok(regUser);
        }
    }
}
