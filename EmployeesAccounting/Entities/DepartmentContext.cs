using System.Data.Entity;

namespace EmployeesAccounting.Models
{
    public class DepartmentContext : DbContext
    {
        public DepartmentContext() : base("DepartmentConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(id => new { id.EmployeeId });
            modelBuilder.Entity<Department>().HasKey(id => new { id.DepartmentId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}