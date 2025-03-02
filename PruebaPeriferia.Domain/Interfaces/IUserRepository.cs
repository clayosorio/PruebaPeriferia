using PruebaPeriferia.Domain.Entities;

namespace PruebaPeriferia.Domain.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int departmentId);
        Task<bool> ExistEmployeeByName(string name);
    }
}
