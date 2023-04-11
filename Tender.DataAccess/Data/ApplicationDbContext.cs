using Microsoft.EntityFrameworkCore;
using TenderProject.Models;

namespace TenderProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<EmployeeRole>().HasKey(e => new { e.RoleId, e.EmployeeId });

        }

         public  DbSet<Employee> Employees { get; set; }
        // DbSet <Role> Roles { get; set; }
        public DbSet<SupplierActivity> SupplierActivities { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }   
    }
}
