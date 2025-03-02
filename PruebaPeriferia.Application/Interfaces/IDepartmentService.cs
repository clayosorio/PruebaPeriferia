using PruebaPeriferia.Application.Dtos.Input;
using PruebaPeriferia.Domain.Entities;

namespace PruebaPeriferia.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(int id);
        Task AddDepartmentAsync(DepartmentInputDto department);
        Task<bool> UpdateDepartmentAsync(int id, DepartmentInputDto department);
        Task<bool> DeleteDepartmentAsync(int id);
        Task<decimal> GetDepartmentSalaryAsync(int departmentId);
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int departmentId);
    }
}
