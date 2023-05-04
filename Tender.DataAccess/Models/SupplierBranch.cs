using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderProject.Models;

namespace Tender.DataAccess.Models
{
    public class SupplierBranch:TimeStamp
    {
        public int Id { get; set; }
        public Supplier Supplier { get; set; }
        [ForeignKey("SupplierId")]
        public int SupplierId { get; set; }


        public City City{ get; set; }
        [ForeignKey("CityId")]
        public int CityId { get; set; }

        public Government Government { get; set; }
        [ForeignKey("GovernmentId")]
        public int GovernmentId { get; set; }

        public string Address { get; set; } 
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }




    }
}
