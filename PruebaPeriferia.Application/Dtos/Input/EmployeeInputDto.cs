using PruebaPeriferia.Domain.Enums;

namespace PruebaPeriferia.Application.Dtos.Input
{
    public class EmployeeInputDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public decimal Salary { get; set; }
        public JobPosition Position { get; set; }
        public int DepartmentId { get; set; }
    }
}
