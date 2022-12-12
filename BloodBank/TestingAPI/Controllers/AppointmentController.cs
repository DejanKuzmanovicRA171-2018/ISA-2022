using BusinessLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentsService _appointmentsService;
        private readonly IEmployeesService _employeesService;

        public AppointmentController(IAppointmentsService appointmentsService, IEmployeesService employeesService)
        {
            _appointmentsService = appointmentsService;
            _employeesService = employeesService;
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
            var employee = await _employeesService.Get(employee => employee.Id == appointmentDto.EmployeeId);
            if (employee is null)
            {
                return BadRequest($"Employee with id: {appointmentDto.EmployeeId} doesn't exist");
            }
            var appointment = new Appointment
            {
                EmployeeId = appointmentDto.EmployeeId,
                TransfusionCenterId = appointmentDto.TransfusionCenterId,
                DateTime = appointmentDto.DateTime,
                IsAvailable = true,
                Duration = appointmentDto.Duration

            };
            await _appointmentsService.Create(appointment);
            return Ok(appointment);
        }
        [HttpPut("ScheduleAnAppointment"), AllowAnonymous/* Authorize(Roles = "RegUser")*/]
        public async Task<IActionResult> ScheduleAppointment(RegUser regUser, int appointmentId)
        {
            await _appointmentsService.ScheduleAppointment(regUser, appointmentId);
            return Ok(appointmentId);
        }
        [HttpPut("CancelAnAppintment"), AllowAnonymous/*Authorize(Roles = "RegUser")*/]
        public async Task<IActionResult> CancelAppointment(RegUser regUser, int appointmentId)
        {
            await _appointmentsService.CancelAppointment(regUser, appointmentId);
            return Ok(appointmentId);
        }
    }
}
