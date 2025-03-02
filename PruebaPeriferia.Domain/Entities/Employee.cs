using PruebaPeriferia.Domain.Enums;

namespace PruebaPeriferia.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public decimal Salary { get; set; }
        public JobPosition Position { get; set; }
        public int DepartmentId { get; set; }
        public required Department Department { get; set; }
    }
}
