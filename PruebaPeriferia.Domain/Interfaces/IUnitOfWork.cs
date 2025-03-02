using PruebaPeriferia.Domain.Entities;

namespace PruebaPeriferia.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Employee> Employees { get; }
        IGenericRepository<Department> Departments {  get; }
        Task<int> SaveChangesAsync();
    }
}
