using BusinessLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

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
        private readonly IAdminsService _adminsService;
        private readonly IConfiguration _configuration;


        public AuthController(IAuthService authService, IUsersService usersService, IRegUsersService regUsersService, IEmployeesService employeesService, IAdminsService adminsService, IConfiguration configuration)
        {
            _authService = authService;
            _usersService = usersService;
            _regUsersService = regUsersService;
            _employeesService = employeesService;
            _adminsService = adminsService;
            _configuration = configuration;
        }
        [HttpPost("register/regular"), AllowAnonymous]
        public async Task<ActionResult<User>> RegisterR(UserDto request)
        {
            _authService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var u = new User
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = request.Role
            };

            if (u.Role == "RegUser")
            {
                await _usersService.Create(u);
                var ru = new RegUser
                {
                    User = u,
                    UserID = u.Id,
                    Name = u.Email
                };
                await _regUsersService.Create(ru);
            }
            else
            {
                return BadRequest("Invalid Role!");
            }
            return Ok(u);
        }
        [HttpPost("register/admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> RegisterA(UserDto request)
        {
            _authService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var u = new User
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = request.Role
            };

            if (u.Role == "Employee")
            {
                await _usersService.Create(u);
                var em = new Employee
                {
                    User = u,
                    UserId = u.Id
                };
                await _employeesService.Create(em);
            }
            else if (u.Role == "Admin")
            {
                await _usersService.Create(u);
                var admin = new Admin
                {
                    User = u,
                    UserId = u.Id
                };
                await _adminsService.Create(admin);
            }
            else
            {
                return BadRequest("Invalid Role!");
            }
            return Ok(u);
        }
        [HttpPost("login"), AllowAnonymous]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var user = await _usersService.Get(user => user.Email == request.Email);
            if (user == null)
                return BadRequest("User not found!");
            if (!_authService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized("Wrong password!");
            string token = _authService.CreateToken(user, _configuration.GetSection("AppSettings:Token").Value);

            return Ok(token);
        }

    }
}
