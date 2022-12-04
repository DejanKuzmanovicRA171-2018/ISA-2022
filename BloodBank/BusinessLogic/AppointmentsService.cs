using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using Models;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace BusinessLogic
{
    public class AppointmentsService : IAppointmentsService
    {
        private readonly IRepositoryWrapper _repository;
        public AppointmentsService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public async Task Create(Appointment entity)
        {
            var appointment = await _repository.Appointment.GetAppointment(a => a.DateTime == entity.DateTime);
            if (appointment is not null)
                throw new BusinessException($"Appointment at: {entity.DateTime} already exists", System.Net.HttpStatusCode.BadRequest);
            await _repository.Appointment.CreateAppointment(entity);
            await _repository.Save();
        }

        public async void Delete(Appointment entity)
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

        public async void Update(Appointment entity)
        {
            var appointment = await _repository.Appointment.GetAppointment(a => a.Id == entity.Id);
            if (appointment is null)
                throw new BusinessException("[Update] Appointment doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.Appointment.UpdateAppointment(entity);
            await _repository.Save();
        }
    }
}
