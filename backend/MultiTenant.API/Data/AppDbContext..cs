using Microsoft.EntityFrameworkCore;
using MultiTenant.API.Models;

namespace MultiTenant.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Alice", TenantId = "Tenant1" },
                new Employee { Id = 2, Name = "Bob", TenantId = "Tenant2" }
            );
        }
    }
}
