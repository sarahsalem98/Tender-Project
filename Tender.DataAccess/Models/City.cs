using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderProject.Models;

namespace Tender.DataAccess.Models
{
    public class City:TimeStamp
    {
        public int Id { get; set; } 
        public Government Government { get; set; }
        [ForeignKey("GovernmentId")]
        public int ? GovernmentId { get; set; }

        public string? Name_Ar { get; set; }
        public string Name_En { get; set; }   
        
    }
}
