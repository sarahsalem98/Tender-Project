using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderProject.Models;

namespace Tender.DataAccess.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
