using System.ComponentModel.DataAnnotations.Schema;

namespace TenderProject.Models
{
    public class EmployeeRole
    {
        public Employee Employee { get; set; }
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }

        public Role Role { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; } 
    }
}
