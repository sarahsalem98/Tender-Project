using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using TenderProject.Models;

namespace TenderProject.Areas.Admin.Models
{
    public class UserVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
       
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public int? RoleId { get; set; }  
        public List<PermitedPageVM> PermitedPages { get; set; }    
    }
}
