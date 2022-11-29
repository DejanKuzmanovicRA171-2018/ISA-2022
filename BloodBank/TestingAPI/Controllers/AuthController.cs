using BusinessLogic;
using BusinessLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BolnicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUsersService _usersService;
        private readonly IRegUsersService _regUsersService;
        private readonly IEmployeesService _employeesService;
        private readonly IConfiguration _configuration;


        public AuthController(IAuthService authService, IUsersService usersService, IRegUsersService regUsersService, IEmployeesService employeesService, IConfiguration configuration)
        {
            _authService = authService;
            _usersService = usersService;
            _regUsersService = regUsersService;
            _employeesService = employeesService;
            _configuration = configuration;
        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            _authService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var u = new User
            {
                Name = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = request.Role
            };
            await _usersService.Create(u);
            if(u.Role == "Employee")
            {
                var em = new Employee
                {
                    User = u,
                    UserId = u.Id
                };
                await _employeesService.Create(em);
            }else if(u.Role == "RegUser")
            {
                var ru = new RegUser
                {
                    User = u,
                    UserID = u.Id,
                    Name = u.Name
                };
                await _regUsersService.Create(ru);
            }
            else
            {
                return BadRequest("Invalid Role!");
            }
            return Ok(u);
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var user = await _usersService.Get(1); 
            if (user == null)
                return BadRequest("User not found!");
            if (!_authService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized("Wrong password!");
            string token = _authService.CreateToken(user, _configuration.GetSection("AppSettings:Token").Value);

            return Ok(token);
        }
       
    }
}
