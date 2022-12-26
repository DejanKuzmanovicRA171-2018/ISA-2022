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

        public TransfusionCenterController(ITransfusionCentersService transfusionCentersService)
        {
            _transfusionCenterService = transfusionCentersService;
        }
        [HttpGet("GetAllTransfusionCenters"), AllowAnonymous]
        public async Task<IActionResult> GetTransfusionCenters()
        {
            return Ok(await _transfusionCenterService.GetAll());
        }
        [HttpGet("GetSingleTransfusionCenterById")]
        public async Task<IActionResult> GetSingleTransfusionCenterId(int Id)
        {
            return Ok(await _transfusionCenterService.Get(tc => tc.Id == Id));
        }
        [HttpGet("GetSingleTransfusionCenterByName")]
        public async Task<IActionResult> GetSingleTransfusionCenterName(string Name)
        {
            return Ok(await _transfusionCenterService.Get(tc => tc.Name == Name));
        }
        [HttpPost("CreateTransfusionCenter"), AllowAnonymous]
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
