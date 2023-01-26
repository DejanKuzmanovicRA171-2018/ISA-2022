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
    public class TransfusionCenterController : ControllerBase
    {
        private readonly ITransfusionCentersService _transfusionCenterService;
        private readonly IAppointmentsService _appointmentsService;

        public TransfusionCenterController(ITransfusionCentersService transfusionCentersService, IAppointmentsService appointmentsService)
        {
            _transfusionCenterService = transfusionCentersService;
            _appointmentsService = appointmentsService;
        }
        [HttpGet("GetAllTransfusionCenters"), AllowAnonymous]
        public async Task<IActionResult> GetTransfusionCenters()
        {
            return Ok(await _transfusionCenterService.GetAll());
        }
        [HttpGet("GetSingleTransfusionCenterById"), AllowAnonymous]
        public async Task<IActionResult> GetSingleTransfusionCenterId(int Id)
        {
            return Ok(await _transfusionCenterService.Get(tc => tc.Id == Id));
        }
        [HttpGet("GetSingleTransfusionCenterByName"), AllowAnonymous]
        public async Task<IActionResult> GetSingleTransfusionCenterName(string Name)
        {
            return Ok(await _transfusionCenterService.Get(tc => tc.Name == Name));
        }
        [HttpGet("GetAllTCsAppointmentDateTime"), AllowAnonymous]
        public async Task<IActionResult> GetTCsAppointmentDateTime(DateTime dateTime)
        {
            List<TCAppointmentDto> response = new List<TCAppointmentDto>();

            var appointments = await _appointmentsService.GetAllByCondition(appointment => DateTime.Compare(appointment.DateTime, dateTime) == 0
                                                                         && appointment.IsAvailable == true);
            var allCenters = await _transfusionCenterService.GetAll();
            foreach (var center in allCenters)
            {
                var appointment = await _appointmentsService.GetWithoutException(appointment => appointment.TransfusionCenterId == center.Id
                                    && DateTime.Compare(appointment.DateTime, dateTime) == 0);
                if (appointment is null)
                {
                    var dto = new TCAppointmentDto
                    {
                        Id = center.Id,
                        Name = center.Name,
                        Address = center.Address,
                        Location = center.Location,
                        Description = center.Description,
                        Rating = center.Rating,
                        AppointmentId = -1,
                        StartDate = dateTime,

                    };
                    response.Add(dto);
                }
            }

            foreach (var appointment in appointments)
            {
                var center = await _transfusionCenterService.Get(tc => tc.Id == appointment.TransfusionCenterId);
                var dto = new TCAppointmentDto
                {
                    Id = center.Id,
                    Name = center.Name,
                    Address = center.Address,
                    Location = center.Location,
                    Description = center.Description,
                    Rating = center.Rating,
                    AppointmentId = appointment.Id,
                    StartDate = dateTime

                };
                response.Add(dto);
            }
            return Ok(response);
        }
        [HttpPost("CreateTransfusionCenter"), AllowAnonymous]
        public async Task<IActionResult> CreateTransfusionCenter(TransfusionCenterDto tcDto)
        {
            var tc = new TransfusionCenter
            {
                Name = tcDto.Name,
                Address = tcDto.Address,
                Description = tcDto.Description,
                Location = tcDto.Location,
                Rating = 0
            };
            await _transfusionCenterService.Create(tc);
            return Ok(tc);
        }
        [HttpPut("UpdateTransfusionCenter"), AllowAnonymous]
        public async Task<IActionResult> UpdateTransfusionCenter(TransfusionCenter tc)
        {
            await _transfusionCenterService.Update(tc);
            return Ok(tc);
        }
        [HttpDelete("DeleteTransfusionCenter"), AllowAnonymous]
        public async Task<IActionResult> DeleteTransfusionCenter(string tcName)
        {
            var tc = new TransfusionCenter
            {
                Name = tcName
            };
            await _transfusionCenterService.Delete(tc);
            return Ok(tc.Name);
        }
    }
}
