using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using Models;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace BusinessLogic
{
    public class SurveysService : ISurveysService
    {
        private readonly IRepositoryWrapper _repository;
        public SurveysService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public async Task Create(Survey entity)
        {
            var survey = await _repository.Survey.GetSurvey(s => s.Id == entity.Id);
            if (survey is not null)
                throw new BusinessException($"Survey with UserId: {entity.Id} already exists", System.Net.HttpStatusCode.BadRequest);
            await _repository.Survey.CreateSurvey(entity);
            await _repository.Save();
        }

        public async Task Delete(Survey entity)
        {
            var survey = await _repository.Survey.GetSurvey(s => s.Id == entity.Id);
            if (survey is null)
                throw new BusinessException("[Delete] Survey doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.Survey.DeleteSurvey(survey);
            await _repository.Save();
        }

        public async Task<Survey> Get(Expression<Func<Survey, bool>> expression)
        {
            var survey = await _repository.Survey.GetSurvey(expression);
            if (survey is null)
                throw new BusinessException("Survey not found", System.Net.HttpStatusCode.NotFound);
            return survey;
        }

        public async Task<IEnumerable<Survey>> GetAll()
        {
            return await _repository.Survey.GetAllSurveysAsync();
        }

        public async Task Update(Survey entity)
        {
            var survey = await _repository.Survey.GetSurvey(s => s.Id == entity.Id);
            if (survey is null)
                throw new BusinessException("[Update] Survey doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.Survey.Update(entity);
            await _repository.Save();
        }
    }
}
