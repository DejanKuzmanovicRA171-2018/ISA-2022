using Repository.DatabaseContext;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DataContext _context;
        private IUserRepository _user;
        private IRegUserRepository _regUser;
        private IEmployeeRepository _employee;

        public IUserRepository User
        {
            get
            {
                if(_user == null)
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
