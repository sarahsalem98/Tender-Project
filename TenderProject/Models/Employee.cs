using System.ComponentModel;

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

     // public IList<EmployeeRole> Roles { get; set; }

    }
}
