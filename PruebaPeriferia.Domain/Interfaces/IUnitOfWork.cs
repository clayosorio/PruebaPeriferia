using PruebaPeriferia.Domain.Entities;

namespace PruebaPeriferia.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IGenericRepository<Department> Departments {  get; }
        Task<int> SaveChangesAsync();
    }
}
