using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaPeriferia.Domain.Entities;

namespace PruebaPeriferia.Infraestructure.Persitence.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(u => u.Id);
        }
    }
}
