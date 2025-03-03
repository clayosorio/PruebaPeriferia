using Mapster;
using Moq;
using PruebaPeriferia.Application.Dtos.Input;
using PruebaPeriferia.Domain.Entities;
using PruebaPeriferia.Domain.Interfaces;

namespace PeriferiaPruebaTest.Mock
{
    public class MockUnitOfWork
    {
        public Mock<IUnitOfWork> UnitOfWorkMock { get; }
        public Mock<IEmployeeRepository> EmployeeRepositoryMock { get; }

        public MockUnitOfWork()
        {
            UnitOfWorkMock = new Mock<IUnitOfWork>();
            EmployeeRepositoryMock = new Mock<IEmployeeRepository>();

            UnitOfWorkMock.Setup(u => u.Employees).Returns(EmployeeRepositoryMock.Object);
        }

        public void SetupGetAllEmployees(IEnumerable<Employee> employees)
        {
            EmployeeRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employees);
        }

        public void SetupGetEmployeeById(int id, Employee employee)
        {
            EmployeeRepositoryMock.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(employee);
        }

        public void SetupUpdateEmployeeAsync(Employee employee)
        {
            EmployeeRepositoryMock.Setup(repo => repo.Update(employee));
        }
    }
}
