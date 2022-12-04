using BusinessLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository.Interfaces;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCAdminController : ControllerBase
    {
        private readonly ITCAdminsService _tcAdminsService;
        private readonly IEmployeesService _employeesService;
        private readonly ITransfusionCentersService _transfusionCentersService;

        public TCAdminController(ITCAdminsService tcAdminsService, IEmployeesService employeesService, ITransfusionCentersService transfusionCentersService)
        {
            _tcAdminsService = tcAdminsService;
            _employeesService = employeesService;
            _transfusionCentersService = transfusionCentersService;
        }
        [HttpGet("GetAllTCAdmins")]
        public async Task<IActionResult> GetTCAdmins()
        {
            return Ok(await _tcAdminsService.GetAll());
        }
        [HttpGet("GetSingleTCAdmin")]
        public async Task<IActionResult> GetSingleTCAdmin(TCAdmin request)
        {
            return Ok(await _tcAdminsService.Get(tcAdmin => tcAdmin.TransfusionCenterId == request.TransfusionCenterId && tcAdmin.EmployeeId == request.EmployeeId));
        }
        [HttpPost("CreateTCAdmin"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateTCAdmin(TCAdminDto request)
        {
            var tcAdmin = new TCAdmin
            {
                TransfusionCenterId = request.TransfusionCenterId,
                EmployeeId = request.EmployeeId
            };
            tcAdmin.Employee = await _employeesService.Get(employee => employee.Id == request.EmployeeId);
            tcAdmin.TransfusionCenter = await _transfusionCentersService.Get(tc => tc.Id == request.TransfusionCenterId);
            await _tcAdminsService.Create(tcAdmin);
            return Ok(tcAdmin);
        }
    }
}
