using BusinessLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransfusionCenterController : ControllerBase
    {
        private readonly ITransfusionCentersService _transfusionCenterService;

        public TransfusionCenterController(ITransfusionCentersService transfusionCentersService)
        {
            _transfusionCenterService = transfusionCentersService;
        }
        [HttpGet("GetAllTransfusionCenters"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetTransfusionCenters()
        {
            return Ok(await _transfusionCenterService.GetAll());
        }
        [HttpGet("GetSingleTransfusionCenter"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetSingleTransfusionCenter(int Id)
        {
            return Ok(await _transfusionCenterService.Get(tc => tc.Id == Id));
        }
        [HttpPost("CreateTransfusionCenter")]
        public async Task<IActionResult> CreateTransfusionCenter(TransfusionCenterDto tcDto)
        {
            var tc = new TransfusionCenter
            {
                Name = tcDto.Name,
                Address = tcDto.Address,
                Description = tcDto.Description,
                Rating = 0
            };
            await _transfusionCenterService.Create(tc);
            return Ok(tc);
        }
    }
}
