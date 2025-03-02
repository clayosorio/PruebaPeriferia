using Mapster;
using PruebaPeriferia.Application.Dtos.Input;
using PruebaPeriferia.Application.Interfaces;
using PruebaPeriferia.Domain.Entities;
using PruebaPeriferia.Domain.Interfaces;

namespace PruebaPeriferia.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _unitOfWork.Employees.GetAllAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _unitOfWork.Employees.GetByIdAsync(id);
        }

        public async Task AddEmployeeAsync(EmployeeInputDto employee)
        {
            await _unitOfWork.Employees.AddAsync(employee.Adapt<Employee>());
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateEmployeeAsync(EmployeeInputDto employee)
        {
            var existingEmployee = await _unitOfWork.Employees.GetByIdAsync(employee.Id);
            if (existingEmployee == null) return false;

            existingEmployee.Name = employee.Name;
            existingEmployee.Email = employee.Email;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.Position = employee.Position;
            existingEmployee.DepartmentId = employee.DepartmentId;

            _unitOfWork.Employees.Update(existingEmployee);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee == null) return false;

            _unitOfWork.Employees.Delete(employee);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
