using Models;

namespace BusinessLogic.Interfaces
{
    public interface IAppointmentsService : IBaseService<Appointment>
    {
        Task ScheduleAppointment(RegUser user, int appointmentId);
        Task CancelAppointment(RegUser user, int appointmentId);
    }
}
