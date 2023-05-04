using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderProject.Models;
using TenderProject.Repository.IRepository;

namespace Tender.DataAccess.Repository.IRepository
{
    public interface IEmployeeRepo:IRepo<Employee>
    {
        public void Update(Employee employee);  

    }
}
