using Models;
using System.Linq.Expressions;

namespace BusinessLogic.Interfaces
{
    public interface IAppointmentsService : IBaseService<Appointment>
    {
        Task ScheduleAppointment(RegUser user, int appointmentId);
        Task CancelAppointment(RegUser user, int appointmentId);
        Task<IEnumerable<Appointment>> GetAllByCondition(Expression<Func<Appointment, bool>> expression);
        Task<Appointment> GetWithoutException(Expression<Func<Appointment, bool>> expression);
    }
}
