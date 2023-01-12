using BusinessLogic.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveysService _surveysService;
        private readonly IRegUsersService _regUsersService;

        public SurveyController(ISurveysService surveysService, IRegUsersService regUsersService)
        {
            _surveysService = surveysService;
            _regUsersService = regUsersService;
        }
        [HttpGet("GetSingleSurvey")]
        public async Task<IActionResult> GetSurvey(int Id)
        {
            return Ok(await _surveysService.Get(s => s.Id == Id));
        }
        [HttpGet("GetAllSurveys")]
        public async Task<IActionResult> GetAllSurveys()
        {
            return Ok(await _surveysService.GetAll());
        }
        [HttpPost("CreateSurvey")]
        public async Task<IActionResult> CreateSurvey(SurveyDto request)
        {
            var survey = new Survey
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                JMBG = request.JMBG,
                Gender = request.Gender,
                ResidenceAddress = request.ResidenceAddress,
                NumberOfPreviousDonations = request.NumberOfPreviousDonations,
                PhoneNumber = request.PhoneNumber,
                Location = request.Location,
                Q1 = request.Q1,
                Q2 = request.Q2,
                DateOfSubmition = DateTime.UtcNow
            };
            await _surveysService.Create(survey);
            return Ok(survey);
        }
        [HttpPut("UpdateSurvey")]
        public async Task<IActionResult> UpdateSurvey(SurveyDto request)
        {
            var survey = new Survey
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                JMBG = request.JMBG,
                Gender = request.Gender,
                ResidenceAddress = request.ResidenceAddress,
                NumberOfPreviousDonations = request.NumberOfPreviousDonations,
                PhoneNumber = request.PhoneNumber,
                Location = request.Location,
                Q1 = request.Q1,
                Q2 = request.Q2,
                DateOfSubmition = DateTime.UtcNow
            };
            await _surveysService.Update(survey);
            return Ok(survey);
        }
        [HttpDelete("DeleteSurvey")]
        public async Task<IActionResult> DeleteSurvey(Survey survey)
        {
            await _surveysService.Delete(survey);
            return Ok(survey);

        }

    }
}
