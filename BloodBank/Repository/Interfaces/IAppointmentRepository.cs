using Models;
using System.Linq.Expressions;

namespace Repository.Interfaces
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment> GetAppointment(Expression<Func<Appointment, bool>> expression);
        Task CreateAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(Appointment appointment);
    }
}
