using PruebaPeriferia.Application.Interfaces;
using PruebaPeriferia.Domain.Entities;
using PruebaPeriferia.Domain.Interfaces;

namespace PruebaPeriferia.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IGenericRepository<Department> _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _departmentRepository = _unitOfWork.Departments;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _departmentRepository.GetAllAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _departmentRepository.GetByIdAsync(id);
        }

        public async Task AddDepartmentAsync(Department department)
        {
            await _departmentRepository.AddAsync(department);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateDepartmentAsync(Department department)
        {
            var existingDepartment = await _departmentRepository.GetByIdAsync(department.Id);
            if (existingDepartment == null) return false;

            existingDepartment.Name = department.Name;

            _departmentRepository.Update(existingDepartment);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null) return false;

            _departmentRepository.Delete(department);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
