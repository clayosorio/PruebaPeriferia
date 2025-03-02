using Mapster;
using PruebaPeriferia.Application.Dtos.Input;
using PruebaPeriferia.Application.Interfaces;
using PruebaPeriferia.Domain.Entities;
using PruebaPeriferia.Domain.Enums;
using PruebaPeriferia.Domain.Interfaces;

namespace PruebaPeriferia.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _unitOfWork.Departments.GetAllAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _unitOfWork.Departments.GetByIdAsync(id);
        }

        public async Task AddDepartmentAsync(DepartmentInputDto department)
        {
            await _unitOfWork.Departments.AddAsync(department.Adapt<Department>());
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateDepartmentAsync(int id, DepartmentInputDto department)
        {
            var existingDepartment = await _unitOfWork.Departments.GetByIdAsync(id);
            if (existingDepartment == null) return false;

            existingDepartment.Name = department.Name;

            _unitOfWork.Departments.Update(existingDepartment);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);
            if (department == null) return false;

            _unitOfWork.Departments.Delete(department);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int departmentId)
        {
            return _unitOfWork.Employees.GetEmployeesByDepartmentAsync(departmentId);
        }

        public async Task<decimal> GetDepartmentSalaryAsync(int departmentId) 
        {
            var employees = await _unitOfWork.Employees.GetEmployeesByDepartmentAsync(departmentId);

            var salaryRules = new Dictionary<JobPosition, Func<Employee, decimal>>
            {
                { JobPosition.Developer, u => u.Salary * 1.1m },
                { JobPosition.Manager, u => u.Salary * 1.2m },
                { JobPosition.HR, u => u.Salary },
                { JobPosition.Sales, u => u.Salary }
            };

            return employees.Sum(employee => salaryRules[employee.Position](employee));
        }
    }
}
