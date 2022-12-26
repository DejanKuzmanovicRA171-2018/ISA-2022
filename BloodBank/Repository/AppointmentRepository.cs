using Microsoft.EntityFrameworkCore;
using Models;
using Repository.DatabaseContext;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace Repository
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(DataContext context) : base(context)
        {
        }

        public async Task CreateAppointment(Appointment appointment)
        {
            await Create(appointment);
        }

        public void DeleteAppointment(Appointment appointment)
        {
            Delete(appointment);
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Appointment> GetAppointment(Expression<Func<Appointment, bool>> expression)
        {
            return await FindByCondition(expression).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointments(Expression<Func<Appointment, bool>> expression)
        {
            return await FindByCondition(expression).ToListAsync();
        }

        public void UpdateAppointment(Appointment appointment)
        {
            Update(appointment);
        }
    }
}
