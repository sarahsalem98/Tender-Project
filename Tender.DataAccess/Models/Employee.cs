using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TenderProject.Models
{
    public class Employee:TimeStamp
    {
      public int Id { get; set; }
      public string? Name { get; set; }
      public string Email { get; set; } 
        [DefaultValue(false)]     
      public bool EmailConfirmed { get; set; }  
      public string Password { get; set; }  
      public string? PhoneNumber { get; set; }

        public Role Role { get; set; }
        [ForeignKey("RoleId")]
        [Column(Order =2)]
        public int? RoleId { get; set; }
        // public List<EmployeeRole> EmployeeRole{ get; set; }

    }
}
