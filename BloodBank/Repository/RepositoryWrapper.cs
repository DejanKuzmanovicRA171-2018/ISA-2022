using Repository.DatabaseContext;
using Repository.Interfaces;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DataContext _context;
        private IRegUserRepository _regUser;
        private IEmployeeRepository _employee;
        private ITransfusionCenterRepository _transfusionCenter;
        private IAdminRepository _admin;
        private IAppointmentRepository _appointment;
        private IBloodRepository _blood;
        private ISpentBloodRepository _spentBlood;


        public IRegUserRepository RegUser
        {
            get
            {
                if (_regUser == null)
                {
                    _regUser = new RegUserRepository(_context);
                }
                return _regUser;
            }
        }
        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_context);
                }
                return _employee;
            }
        }
        public ITransfusionCenterRepository TransfusionCenter
        {
            get
            {
                if (_transfusionCenter == null)
                {
                    _transfusionCenter = new TransfusionCenterRepository(_context);
                }
                return _transfusionCenter;
            }
        }

        public IAdminRepository Admin
        {
            get
            {
                if (_admin == null)
                {
                    _admin = new AdminRepository(_context);
                }
                return _admin;
            }
        }
        public IAppointmentRepository Appointment
        {
            get
            {
                if (_appointment == null)
                {
                    _appointment = new AppointmentRepository(_context);
                }
                return _appointment;
            }
        }
        public IBloodRepository Blood
        {
            get
            {
                if (_blood == null)
                {
                    _blood = new BloodRepository(_context);
                }
                return _blood;
            }
        }
        public ISpentBloodRepository SpentBlood
        {
            get
            {
                if (_spentBlood == null)
                {
                    _spentBlood = new SpentBloodRepository(_context);
                }
                return _spentBlood;
            }
        }

        public RepositoryWrapper(DataContext context)
        {
            _context = context;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
