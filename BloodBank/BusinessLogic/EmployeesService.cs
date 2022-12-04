using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using Models;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace BusinessLogic
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IRepositoryWrapper _repository;
        public EmployeesService(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task Create(Employee entity)
        {
            var employee = await _repository.Employee.GetEmployee(e => e.User.Email == entity.User.Email);
            if (employee is not null)
                throw new BusinessException($"Employee with email: {entity.User.Email} already exists", System.Net.HttpStatusCode.BadRequest);
            await _repository.Employee.Create(entity);
            await _repository.Save();
        }

        public async void Delete(Employee entity)
        {
            var user = await _repository.User.GetUser(u => u.Id == entity.User.Id);
            // Should never happen (Employees are created based on users)
            if (user is null)
                throw new BusinessException("User for the given employee doesn't exist", System.Net.HttpStatusCode.InternalServerError);
            entity.User = user;

            var employee = await _repository.Employee.GetEmployee(e => e.User.Email == entity.User.Email);
            if (employee is null)
                throw new BusinessException("[Delete] Employee doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.Employee.Delete(entity);
            await _repository.Save();
        }

        public async Task<Employee> Get(Expression<Func<Employee, bool>> expression)
        {
            var employee = await _repository.Employee.GetEmployee(expression);
            if (employee is null)
                throw new BusinessException("Employee with matching parameters doesn't exist", System.Net.HttpStatusCode.NotFound);
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _repository.Employee.GetAllEmployeesAsync();
        }

        public async void Update(Employee entity)
        {
            var employee = await _repository.Employee.GetEmployee(e => e.User.Email == entity.User.Email);
            if (employee is null)
                throw new BusinessException("[Update] Employee doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.Employee.UpdateEmployee(entity);
            await _repository.Save();
        }
    }
}
