using BusinessLogic;
using BusinessLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository.DatabaseContext;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentsService _appointmentsService;
        private readonly IEmployeesService _employeesService;
        private readonly IRegUsersService _regUsersService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITransfusionCentersService _transfusionCentersService;

        public AppointmentController(IAppointmentsService appointmentsService, IEmployeesService employeesService,
                                     IRegUsersService regUsersService, UserManager<IdentityUser> userManager,
                                     ITransfusionCentersService transfusionCentersService)
        {
            _appointmentsService = appointmentsService;
            _employeesService = employeesService;
            _regUsersService = regUsersService;
            _userManager = userManager;
            _transfusionCentersService = transfusionCentersService;
        }
        [HttpGet("GetAllAppointments")]
        public async Task<IActionResult> GetAppointments()
        {
            return Ok(await _appointmentsService.GetAll());
        }
        [HttpGet("GetSingleAppointment")]
        public async Task<IActionResult> GetSingleAdmin(int Id)
        {
            return Ok(await _appointmentsService.Get(appointment => appointment.Id == Id));
        }
        [HttpPost("CreateAppointment"), AllowAnonymous /*Authorize(Roles = "Employee")*/]
        public async Task<ActionResult<Appointment>> CreateAppointment(AppointmentDto appointmentDto)
        {
            var user = await _userManager.FindByEmailAsync(appointmentDto.Email);
            if (user is null)
                return BadRequest($"User with email: {appointmentDto.Email} doesn't exist");
            var employee = await _employeesService.Get(employee => employee.UserId == user.Id);
            if (employee is null)
            {
                return BadRequest($"User is not employee");
            }
            var appointment = new Appointment
            {
                EmployeeId = employee.Id,
                TransfusionCenterId = employee.TransfusionCenterId,
                DateTime = appointmentDto.DateTime,
                IsAvailable = true,
                Duration = appointmentDto.Duration

            };
            await _appointmentsService.Create(appointment);
            return Ok(appointment);
        }
        [HttpPut("ScheduleAnAppointment"), AllowAnonymous/* Authorize(Roles = "RegUser")*/]
        public async Task<IActionResult> ScheduleAppointment(RegUser regUser, int appointmentId, string centerName, DateTime startDate)
        {
            if (appointmentId == -1)
            {
                var center = await _transfusionCentersService.Get(center => center.Name == centerName);
                var employee = await _employeesService.Get(employee => employee.TransfusionCenterId == center.Id);
                var appointment = new Appointment
                {
                    EmployeeId = employee.Id,
                    TransfusionCenterId = employee.TransfusionCenterId,
                    DateTime = startDate,
                    IsAvailable = false,
                    Duration = 30,
                    RegUserId = regUser.Id,
                };
                await _appointmentsService.Create(appointment);
            }
            else
            {
                await _appointmentsService.ScheduleAppointment(regUser, appointmentId);
            }

            return Ok(appointmentId);
        }
        [HttpPut("CancelAnAppointment"), AllowAnonymous/*Authorize(Roles = "RegUser")*/]
        public async Task<IActionResult> CancelAppointment(RegUser regUser, int appointmentId)
        {
            await _appointmentsService.CancelAppointment(regUser, appointmentId);
            return Ok(appointmentId);
        }
        [HttpGet("GetAllAppointmentsDateTime")]
        public async Task<IActionResult> GetAllAppointmentsDateTime(DateTime dateTime)
        {
            return Ok(await _appointmentsService.GetAllByCondition(appointment => DateTime.Compare(appointment.DateTime, dateTime) == 0
                                                                && appointment.IsAvailable == true));
        }
        [HttpGet("GetAllUpcomingAppointmentsCenter"), AllowAnonymous]
        public async Task<IActionResult> GetAllUpcomingAppointmentsCenter(string centerName)
        {
            var center = await _transfusionCentersService.Get(center => center.Name == centerName);
            return Ok(await _appointmentsService.GetAllByCondition(appointment => appointment.IsAvailable == true                 // All available appointments
                                                                && appointment.TransfusionCenterId == center.Id                   // For requested center 
                                                                && DateTime.Compare(appointment.DateTime, DateTime.UtcNow) > 0)); // Appointments have not passed
        }
        [HttpGet("GetAllAppointmentsCenter"), AllowAnonymous]
        public async Task<IActionResult> GetAllAppointmentsCenter(string centerName)
        {
            var center = await _transfusionCentersService.Get(center => center.Name == centerName);
            return Ok(await _appointmentsService.GetAllByCondition(appointment =>                 // All available appointments
                                                                appointment.TransfusionCenterId == center.Id));                   // For requested center 
                                                                 
        }
        [HttpGet("GetAllPastAppointmentsUser"), AllowAnonymous]
        public async Task<IActionResult> GetAllPastAppointmentsUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
                return BadRequest($"No User with email: {email}");
            var regUser = await _regUsersService.Get(regUser => regUser.UserID == user.Id);
            return Ok(await _appointmentsService.GetAllByCondition(appointment => appointment.RegUserId == regUser.Id
                                                                && DateTime.Compare(appointment.DateTime, DateTime.UtcNow) < 0)); //Appointments happened before Now
        }
        [HttpGet("GetAllUpcomingAppointmentsUser"), AllowAnonymous]
        public async Task<IActionResult> GetAllUpcomingAppointmentsUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
                return BadRequest($"No User with email: {email}");
            var regUser = await _regUsersService.Get(regUser => regUser.UserID == user.Id);
            return Ok(await _appointmentsService.GetAllByCondition(appointment => appointment.RegUserId == regUser.Id
                                                                && DateTime.Compare(appointment.DateTime, DateTime.UtcNow) > 0)); //Appointments are after Now
        }
    }
}
