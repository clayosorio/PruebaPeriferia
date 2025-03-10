﻿namespace PruebaPeriferia.Domain.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
