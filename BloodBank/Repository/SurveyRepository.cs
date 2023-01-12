using Microsoft.EntityFrameworkCore;
using Models;
using Repository.DatabaseContext;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace Repository
{
    public class SurveyRepository : RepositoryBase<Survey>, ISurveyRepository
    {
        public SurveyRepository(DataContext context) : base(context)
        {
        }
        public async Task CreateSurvey(Survey survey)
        {
            await _context.AddAsync(survey);
        }

        public void DeleteSurvey(Survey survey)
        {
            Delete(survey);
        }

        public async Task<IEnumerable<Survey>> GetAllSurveysAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Survey> GetSurvey(Expression<Func<Survey, bool>> expression)
        {
            return await FindByCondition(expression).FirstOrDefaultAsync();
        }

        public void UpdateSurvey(Survey survey)
        {
            Update(survey);
        }
    }
}
