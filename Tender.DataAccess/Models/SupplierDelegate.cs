using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderProject.Models;

namespace Tender.DataAccess.Models
{
  //  [Table("SupplierDelegates")]
    public class SupplierDelegate:TimeStamp
    {

        public int Id { get; set; }
        public Supplier Supplier{ get; set; }
        [ForeignKey("SupplierId")]
        public int SupplierId { get; set; }
        public string Name { get; set; }    
        public string JobTitle { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
