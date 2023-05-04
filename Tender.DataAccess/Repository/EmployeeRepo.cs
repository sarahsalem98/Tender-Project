using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tender.DataAccess.Repository.IRepository;
using TenderProject.Data;
using TenderProject.Models;
using TenderProject.Repository;

namespace Tender.DataAccess.Repository
{
    public class EmployeeRepo : Repo<Employee>, IEmployeeRepo
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;   
        }

        public void Update(Employee employee)
        {
           // employee.CreatedAt = DateTime.Now;  
            employee.UpdatedAt = DateTime.Now;  
            _db.Employees.Update(employee);
        }
    }
}
