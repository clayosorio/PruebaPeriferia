using PruebaPeriferia.Application.Dtos.Input;
using PruebaPeriferia.Domain.Entities;

namespace PruebaPeriferia.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(EmployeeInputDto employee);
        Task<bool> UpdateEmployeeAsync(EmployeeInputDto employee);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
