using BusinessLogic.Interfaces;
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

        public TCAdminController(ITCAdminsService tcAdminsService)
        {
            _tcAdminsService = tcAdminsService;
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
        public async Task<IActionResult> CreateTCAdmin(TCAdmin request)
        {
            await _tcAdminsService.Create(request);
            return Ok(request);
        }
    }
}
