using Mapster;
using Moq;
using PeriferiaPruebaTest.Mock;
using PruebaPeriferia.Application.Dtos.Input;
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
        }

        [Fact]
        public async Task GetEmployeeByIdAsync_ShouldReturnEmployee() 
        {
            // Arrange
            var employees = new Employee
            { 
                Id = 2, Name = "Jane", Email = "hola@hsadks", Position = JobPosition.Manager, Salary = 2000 
            };

            // Act
            _mockUnitOfWork.SetupGetEmployeeById(employees.Id, employees);

            var result = await _employeeService.GetEmployeeByIdAsync(employees.Id);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddEmployeeAsync_ShouldReturnException_WhenEmailIsInvalid()
        {
            // Arrange
            var employee = new Employee
            {
                Id = 2,
                Name = "Jhon",
                Email = "jhoncorreoinvalid",
                Position = JobPosition.Manager,
                Salary = 2000
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () => await _employeeService.AddEmployeeAsync(employee.Adapt<EmployeeInputDto>()));
        }

        [Fact]
        public async Task AddEmployeeAsync_ShouldReturnException_WhenEmailIsEmpty()
        {
            // Arrange
            var employee = new Employee
            {
                Id = 2,
                Name = "Jhon",
                Email = "",
                Position = JobPosition.Manager,
                Salary = 2000
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () => await _employeeService.AddEmployeeAsync(employee.Adapt<EmployeeInputDto>()));
        }

        [Fact]
        public async Task AddEmployeeAsync_ShouldReturnException_WhenNameIsEmpty()
        {
            // Arrange
            var employee = new Employee
            {
                Id = 2,
                Name = "",
                Email = "hola@hsadks.com",
                Position = JobPosition.Manager,
                Salary = 2000
            };

            // Act
            await Assert.ThrowsAsync<ArgumentException>(async () => await _employeeService.AddEmployeeAsync(employee.Adapt<EmployeeInputDto>()));
        }

        [Fact]
        public async Task UpdateEmplyeeAsync_ShouldReturnFalse() 
        {
            // Arrange
            var employee = new Employee
            {
                Id = 2,
                Name = "Jane",
                Email = "hola@hsadks.com",
                Position = JobPosition.Manager,
                Salary = 2000
            };

            // Act
            var result = await _employeeService.UpdateEmployeeAsync(employee.Adapt<EmployeeInputDto>());

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task UpdateEmplyeeAsync_ShouldReturnException_WhenNameIsEmpty()
        {
            // Arrange
            var employee = new Employee
            {
                Id = 2,
                Name = "",
                Email = "hola@hsadks.com",
                Position = JobPosition.Manager,
                Salary = 2000
            };

            // Act & Assert
            await Assert.ThrowsAsync <ArgumentException>(async () => await _employeeService.UpdateEmployeeAsync(employee.Adapt<EmployeeInputDto>()));
        }

        [Fact]
        public async Task UpdateEmplyeeAsync_ShouldReturnException_WhenEmailIsEmpty()
        {
            // Arrange
            var employee = new Employee
            {
                Id = 2,
                Name = "Jhon",
                Email = "",
                Position = JobPosition.Manager,
                Salary = 2000
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () => await _employeeService.UpdateEmployeeAsync(employee.Adapt<EmployeeInputDto>()));
        }

        [Fact]
        public async Task UpdateEmplyeeAsync_ShouldReturnException_WhenEmailIsInvalid()
        {
            // Arrange
            var employee = new Employee
            {
                Id = 2,
                Name = "Jhon",
                Email = "jhoncorreoinvalid",
                Position = JobPosition.Manager,
                Salary = 2000
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () => await _employeeService.UpdateEmployeeAsync(employee.Adapt<EmployeeInputDto>()));
        }

        [Fact]
        public async Task DeleteEmployeeAsync_ShouldReturnFalse()
        {
            //Arrange
            int id = 2;

            //Act
            var result = await _employeeService.DeleteEmployeeAsync(id);

            //Assert
            Assert.False(result);
        }
    }
}
