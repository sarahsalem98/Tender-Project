using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using TenderProject.Models;
using Microsoft.Build.Framework;

namespace TenderProject.Areas.Admin.Models
{


    public class EmployeeSearch
    {
        public bool IsSearch { get; set; }
        public int Id { get; set; }
 
        public string Name { get; set; }
 
        public string Email { get; set; }
  
  
  
        public string PhoneNumber { get; set; }
       
        public int RoleId { get; set; }
    }
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public int RoleId { get; set; }
    }

   
}
