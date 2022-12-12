using BusinessLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUsersService _usersService;
        private readonly IRegUsersService _regUsersService;
        private readonly IEmployeesService _employeesService;
        private readonly IAdminsService _adminsService;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AuthController(IAuthService authService, IUsersService usersService, IRegUsersService regUsersService, IEmployeesService employeesService,
         IAdminsService adminsService, IConfiguration configuration, IEmailSender emailSender, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _authService = authService;
            _usersService = usersService;
            _regUsersService = regUsersService;
            _employeesService = employeesService;
            _adminsService = adminsService;
            _configuration = configuration;
            _emailSender = emailSender;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpPost("register/regular"), AllowAnonymous]
        public async Task<ActionResult<IdentityUser>> RegisterR(UserDto request)
        {
            if (!(await _roleManager.RoleExistsAsync("RegUser")))
            {
                await _roleManager.CreateAsync(new IdentityRole("RegUser"));
            }
            var u = new IdentityUser()
            {
                UserName = request.Email,
                Email = request.Email
            };
            await _usersService.Create(u, request.Password);
            var user = await _userManager.FindByEmailAsync(request.Email);
            await _userManager.AddToRoleAsync(user, "RegUser");

            var ru = new RegUser()
            {
                User = user,
                UserID = user.Id
            };
            await _regUsersService.Create(ru);

            //Generate and send confirmation email to newly created user 
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(u);
            var confirmationLink = Url.Action("ConfirmEmail", "Auth",
                new { userId = u.Id, token = token }, Request.Scheme);
            await _emailSender.SendEmailAsync(u.Email, "Confirm your account",
                  $"Please confirm your account by clicking this <a href='{confirmationLink}'>link</a>");
            return Ok(u);
        }
        [HttpPost("register/admin"), AllowAnonymous/*Authorize(Roles = "Admin")*/]
        public async Task<ActionResult<IdentityUser>> RegisterA(UserDto request)
        {
            // INITIALIZE ROLES (---TEMPORARY---)
            if (!(await _roleManager.RoleExistsAsync("Employee")))
            {
                await _roleManager.CreateAsync(new IdentityRole("Employee"));
            }
            if (!(await _roleManager.RoleExistsAsync("Admin")))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            //--------------------------------------------------------------//

            var u = new IdentityUser
            {
                Email = request.Email,
                UserName = request.Email
            };
            await _usersService.Create(u, request.Password);

            if (request.Role == "Employee")
            {
                await _userManager.AddToRoleAsync(u, "Employee");
                var em = new Employee
                {
                    User = u,
                    UserId = u.Id
                };
                await _employeesService.Create(em);
            }
            else if (request.Role == "Admin")
            {
                await _userManager.AddToRoleAsync(u, "Admin");
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
        [HttpGet("ConfirmEmail"), AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId is "" || token is "")
            {
                return BadRequest("token or id is invalid");
            }
            var user = await _userManager.FindByIdAsync(userId);
            return Ok(await _userManager.ConfirmEmailAsync(user, token));

        }
        [HttpPost("login"), AllowAnonymous]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return BadRequest($"User for email: {request.Email} doesn't exist");

            var isValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isValid)
            {
                return BadRequest("Password is incorrect");
            }

            if (!user.EmailConfirmed)
            {
                var rs = await _userManager.GetRolesAsync(user);
                var r = rs.Single();

                if (r == "Employee")
                {
                    var tokenReset = _userManager.GeneratePasswordResetTokenAsync(user);
                    return Ok(tokenReset);
                }
                else if (r == "Admin")
                {
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);
                }
                else
                {
                    return BadRequest("Please confirm your email address");
                }
            }

            var roles = await _userManager.GetRolesAsync(user);
            if (roles is null)
            {
                return StatusCode(500, "Unexpected error while getting user role");
            }
            var role = roles.Single();
            string token = _authService.CreateToken(user, _configuration.GetSection("AppSettings:Token").Value, role);

            return Ok(token);
        }
        [HttpPost("ResetPassword"), AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto request)
        {
            if (request.Email is "" || request.Token is "")
            {
                return BadRequest("token or id is invalid");
            }
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return BadRequest("User doesn't exist");
            }
            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);
            if (result.Succeeded)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return Ok(result);
            }
            return BadRequest("invalid token");
        }

    }
}
