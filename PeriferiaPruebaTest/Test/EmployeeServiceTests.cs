using Moq;
using PeriferiaPruebaTest.Mock;
using PruebaPeriferia.Application.Services;
using PruebaPeriferia.Domain.Entities;
using PruebaPeriferia.Domain.Enums;

namespace PeriferiaPruebaTest.Test
{
    public class EmployeeServiceTests
    {
        private readonly EmployeeService _employeeService;
        private readonly MockUnitOfWork _mockUnitOfWork;

        public EmployeeServiceTests()
        {
            _mockUnitOfWork = new MockUnitOfWork();
            _employeeService = new EmployeeService(_mockUnitOfWork.UnitOfWorkMock.Object);
        }

        [Fact]
        public async Task GetAllEmployeesAsync_ShouldReturnEmployees()
        {
            // Arrange
            var employees = new List<Employee>
            {
            new() { Id = 1, Name = "John", Email = "hola@hsadks", Position = JobPosition.Developer, Salary = 1000 },
            new() { Id = 2, Name = "Jane", Email = "hola@hsadks", Position = JobPosition.Manager, Salary = 2000 }
            };

            _mockUnitOfWork.SetupGetAllEmployees(employees);

            // Act
            var result = await _employeeService.GetAllEmployeesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            _mockUnitOfWork.EmployeeRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task GetEmployeeByIdAsync_ShouldReturnEmployee() 
        {
            var employees = new Employee
            { 
                Id = 2, Name = "Jane", Email = "hola@hsadks", Position = JobPosition.Manager, Salary = 2000 
            };

            _mockUnitOfWork.SetupGetEmployeeById(employees.Id, employees);

            var result = await _employeeService.GetEmployeeByIdAsync(employees.Id);

            Assert.NotNull(result);
            _mockUnitOfWork.EmployeeRepositoryMock.Verify(repo => repo.GetByIdAsync(employees.Id), Times.Once);
        }
    }
}
