using BusinessLogic.Interfaces;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IRepositoryWrapper _repository;
        public EmployeesService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public Task Create(Employee entity)
        {
            _repository.Employee.Create(entity);
            _repository.Save();
            return Task.CompletedTask;
        }

        public void Delete(Employee entity)
        {
            _repository.Employee.Delete(entity);
            _repository.Save();
        }

        public async Task<Employee> Get(Expression<Func<Employee, bool>> expression)
        {
            return await _repository.Employee.GetEmployee(expression);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _repository.Employee.GetAllEmployeesAsync();
        }

        public void Update(Employee entity)
        {
            _repository.Employee.Update(entity);
            _repository.Save();
        }
    }
}
