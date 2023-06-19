using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderProject.Models;

namespace Tender.DataAccess.Models
{
    public class SupplierTenderFavourite
    {
        public Supplier Supplier { get; set; }
        [ForeignKey("SupplierId")]
        public int SupplierId { get; set; }

        public Tender Tender { get; set; }
        [ForeignKey("TenderId")]
        public int TenderId { get; set; }   
    }
}
