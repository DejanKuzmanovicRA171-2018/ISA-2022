using Repository.DatabaseContext;
using Repository.Interfaces;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DataContext _context;
        private IUserRepository _user;
        private IRegUserRepository _regUser;
        private IEmployeeRepository _employee;
        private ITransfusionCenterRepository _transfusionCenter;
        private ITCAdminRepository _tcAdmin;
        private IAdminRepository _admin;
        private IAppointmentRepository _appointment;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context);
                }
                return _user;
            }
        }
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
        public ITCAdminRepository TCAdmin
        {
            get
            {
                if (_tcAdmin == null)
                {
                    _tcAdmin = new TCAdminRepository(_context);
                }
                return _tcAdmin;
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
