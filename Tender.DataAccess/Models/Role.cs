using Tender.DataAccess.Models;

namespace TenderProject.Models
{
    public class Role:TimeStamp
    {
        public int Id { get; set; }
        public string? Name_Ar { get; set; }
        public string Name_En { get; set; }
      
       public List<Employee>Employees { get; set; } 
        public List<Permission> Permissions { get; set; }   

    }
}
