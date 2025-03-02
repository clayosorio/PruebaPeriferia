using Microsoft.EntityFrameworkCore;
using PruebaPeriferia.Domain.Entities;
using PruebaPeriferia.Domain.Interfaces;
using PruebaPeriferia.Infraestructure.Persitence.Context;

namespace PruebaPeriferia.Infraestructure.Persitence.Repositories
{
    public class EmployeeRepository(ApplicationDbContext context) : GenericRepository<Employee>(context), IEmployeeRepository
    {
        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int departmentId)
        {
            return await base._context.Employees
                .Where(u => u.DepartmentId == departmentId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> ExistEmployeeByName(string name) 
        {
            return await base._context.Employees.AnyAsync(u => u.Name == name);
        }
    }
}
