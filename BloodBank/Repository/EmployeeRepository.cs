using Models;
using Repository.DatabaseContext;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DataContext context) : base(context)
        {
        }

        public async Task CreateEmployee(Employee employee)
        {
            await _context.AddAsync(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Employee> GetEmployee(int Id)
        {
            return await FindByCondition(employee => employee.Id == Id).FirstOrDefaultAsync();
        }

        public void UpdateEmployee(Employee employee)
        {
            Update(employee);
        }
    }
}
