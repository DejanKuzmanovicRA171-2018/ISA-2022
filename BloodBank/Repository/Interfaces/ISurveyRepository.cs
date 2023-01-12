using Models;
using System.Linq.Expressions;

namespace Repository.Interfaces
{
    public interface ISurveyRepository : IRepositoryBase<Survey>
    {
        Task<IEnumerable<Survey>> GetAllSurveysAsync();
        Task<Survey> GetSurvey(Expression<Func<Survey, bool>> expression);
        Task CreateSurvey(Survey survey);
        void UpdateSurvey(Survey survey);
        void DeleteSurvey(Survey survey);
    }
}
