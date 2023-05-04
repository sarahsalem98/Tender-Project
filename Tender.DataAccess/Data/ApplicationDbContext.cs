using Microsoft.EntityFrameworkCore;
using Tender.DataAccess.Models;
using TenderProject.Models;

namespace TenderProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

          //modelBuilder.Entity<EmployeeRole>().HasKey(e => new { e.RoleId, e.EmployeeId });

        }

         public  DbSet<Employee> Employees { get; set; }
        public DbSet <Role> Roles { get; set; }
         public DbSet<Activity> Activities { get; set; }
         public DbSet<Supplier> Suppliers { get; set; } 
        
        public DbSet<Government> Governments { get; set; }
        public DbSet<City> Cities { get; set; }
      //  public DbSet<SupplierDelegate> SupplierDelegate { get; set; }
       // public DbSet<SupplierBranch> SupplierBranch{ get; set; }

    }
}
