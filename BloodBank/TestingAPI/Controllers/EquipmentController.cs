using BusinessLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IBloodService _bloodService;

        public EquipmentController(IBloodService bloodService)
        {
            _bloodService = bloodService;
        }
        [HttpGet("GetAllBloodTC")]
        public async Task<IActionResult> GetAllUnitsOfBloodTC(int TransfusionCenterId)
        {
            return Ok(await _bloodService.GetMultiple(b => b.TransfusionCenterId == TransfusionCenterId));
        }
        [HttpPost("CreateUnitOfBlood")]
        public async Task<ActionResult<UnitOfBlood>> CreateUnitOfBlood(UnitOfBloodDto request)
        {
            var unitOfBlood = new UnitOfBlood
            {
                TransfusionCenterId = request.TransfusionCenterId,
                Type = request.Type,
                Rh = request.Rh,
                ExpirationDate = DateTime.UtcNow.AddDays(42)
            };
            await _bloodService.Create(unitOfBlood);
            return Ok(unitOfBlood);
        }
        [HttpPost("CreateGeneralEquipment")]
        public async Task<ActionResult<GeneralEquipment>> CreateGeneralEquipment(GeneralEquipmentDto request)
        {
            var generalEquipment = new GeneralEquipment
            {
                Type = request.Type,
                Quantity = request.Quantity
            };
            return Ok("");
        }
        [HttpDelete("DeleteUnitOfBlood")]
        public async Task<IActionResult> DeleteUnitOfBlood(int unitOfBloodId)
        {
            var unitOfBlood = await _bloodService.Get(uob => uob.Id == unitOfBloodId);
            await _bloodService.Delete(unitOfBlood);
            return Ok(unitOfBlood);
        }
    }
}
