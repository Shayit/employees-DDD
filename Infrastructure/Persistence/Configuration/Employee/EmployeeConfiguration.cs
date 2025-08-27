using Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration.SalesHub
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeId);
            builder.Property(e => e.EmployeeId).HasMaxLength(20);
            builder.Property(e => e.FullName).HasMaxLength(255);
            builder.Property(e => e.Salary);
            builder.Property(e => e.Active);
        }
    }
}
