using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Identity;
using Models;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace BusinessLogic
{
    public class AppointmentsService : IAppointmentsService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly UserManager<IdentityUser> _userManager;
        public AppointmentsService(IRepositoryWrapper repository, UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }
        public async Task Create(Appointment entity)
        {
            var appointment = await _repository.Appointment.GetAppointment(a => a.DateTime == entity.DateTime);
            if (appointment is not null)
                throw new BusinessException($"Appointment at: {entity.DateTime} already exists", System.Net.HttpStatusCode.BadRequest);
            await _repository.Appointment.CreateAppointment(entity);
            await _repository.Save();
        }

        public async Task Delete(Appointment entity)
        {
            var appointment = await _repository.Appointment.GetAppointment(a => a.Id == entity.Id);
            if (appointment is null)
                throw new BusinessException("[Delete] Appointment doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.Appointment.DeleteAppointment(entity);
            await _repository.Save();
        }

        public async Task<Appointment> Get(Expression<Func<Appointment, bool>> expression)
        {
            var appointment = await _repository.Appointment.GetAppointment(expression);
            if (appointment is null)
                throw new BusinessException("Appointment doesn't exist", System.Net.HttpStatusCode.NotFound);
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await _repository.Appointment.GetAllAppointmentsAsync();
        }

        public async Task ScheduleAppointment(RegUser user, int appointmentId)
        {
            var appointment = await _repository.Appointment.GetAppointment(appointment => appointment.Id == appointmentId);
            if (appointment is null)
                throw new BusinessException("[Scheduling] Appointment doesn't exist", System.Net.HttpStatusCode.NotFound);
            if (!(appointment.IsAvailable && DateTime.Compare(appointment.DateTime, DateTime.UtcNow) > 0))
                throw new BusinessException("[Scheduling] Appointemnt is either unavailable or has passed", System.Net.HttpStatusCode.BadRequest);

            user.User = await _userManager.FindByIdAsync(user.UserID);
            appointment.IsAvailable = false;
            appointment.RegUser = user;
            appointment.RegUserId = user.Id;
            _repository.Appointment.UpdateAppointment(appointment);
            await _repository.Save();
        }
        public async Task CancelAppointment(RegUser user, int appointmentId)
        {
            var appointment = await _repository.Appointment.GetAppointment(appointment => appointment.Id == appointmentId);
            if (appointment is null)
                throw new BusinessException("[Canceling] Appointment doesn't exist", System.Net.HttpStatusCode.NotFound);
            if (appointment.RegUserId != user.Id || appointment.IsAvailable)
                throw new BusinessException("[Canceling] User has not scheduled this appointment", System.Net.HttpStatusCode.BadRequest);
            if (DateTime.Compare(appointment.DateTime, DateTime.UtcNow.AddDays(1)) < 0)
                throw new BusinessException("[Canceling] Appointment can't be canceled less than 24 hours before", System.Net.HttpStatusCode.BadRequest);

            appointment.IsAvailable = true;
            appointment.RegUser = null;
            appointment.RegUserId = null;
            _repository.Appointment.UpdateAppointment(appointment);
            await _repository.Save();
        }

        public async Task Update(Appointment entity)
        {
            var appointment = await _repository.Appointment.GetAppointment(a => a.Id == entity.Id);
            if (appointment is null)
                throw new BusinessException("[Update] Appointment doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.Appointment.UpdateAppointment(entity);
            await _repository.Save();
        }
    }
}
