using PruebaPeriferia.Domain.Entities;
using PruebaPeriferia.Domain.Interfaces;
using PruebaPeriferia.Infraestructure.Persitence.Context;
using System;

namespace PruebaPeriferia.Infraestructure.Persitence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IEmployeeRepository? _employees;
        private IGenericRepository<Department>? _departments;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEmployeeRepository Employees => _employees ??= new EmployeeRepository(_context);
        public IGenericRepository<Department> Departments => _departments ??= new GenericRepository<Department>(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
