using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Identity;
using Models;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace BusinessLogic
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly UserManager<IdentityUser> _userManager;
        public EmployeesService(IRepositoryWrapper repository, UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task Create(Employee entity)
        {
            var employee = await _repository.Employee.GetEmployee(e => e.User.Email == entity.User.Email);
            if (employee is not null)
                throw new BusinessException($"Employee with email: {entity.User.Email} already exists", System.Net.HttpStatusCode.BadRequest);
            await _repository.Employee.Create(entity);
            await _repository.Save();
        }

        public async Task Delete(Employee entity)
        {
            var user = await _userManager.FindByIdAsync(entity.UserId);
            if (user is null)
                throw new BusinessException("User doesn't exist", System.Net.HttpStatusCode.InternalServerError);

            var employee = await _repository.Employee.GetEmployee(e => e.Id == entity.Id);
            if (employee is null)
                throw new BusinessException("[Delete] Employee doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.Employee.Delete(entity);
            await _userManager.DeleteAsync(user);
            await _repository.Save();
        }

        public async Task<Employee> Get(Expression<Func<Employee, bool>> expression)
        {
            var employee = await _repository.Employee.GetEmployee(expression);
            if (employee is null)
                throw new BusinessException("Employee with matching parameters doesn't exist", System.Net.HttpStatusCode.NotFound);
            employee.User = await _userManager.FindByIdAsync(employee.UserId);
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _repository.Employee.GetAllEmployeesAsync();
        }

        public async Task Update(Employee entity)
        {
            var employee = await _repository.Employee.GetEmployee(e => e.User.Email == entity.User.Email);
            if (employee is null)
                throw new BusinessException("[Update] Employee doesn't exist", System.Net.HttpStatusCode.BadRequest);
            _repository.Employee.UpdateEmployee(entity);
            await _repository.Save();
        }
    }
}
