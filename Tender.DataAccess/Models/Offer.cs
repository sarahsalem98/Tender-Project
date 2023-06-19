using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderProject.Models;

namespace Tender.DataAccess.Models
{
    public class Offer:TimeStamp
    {
        public int Id { get; set; }
        public Supplier Supplier { get; set; }
        [ForeignKey("SupplierId")]
        public int SupplierId { get; set; }

        public Tender Tender { get; set; }
        [ForeignKey("TenderId")]
        public int  TenderId { get; set; }

        public int ExpectedValue { get; set; }  
        public int? Value { get; set; }  
        public int? TarsiaValue { get; set; }


        [DefaultValue(1)]
        public int OfferStatus { get; set; }

        [DefaultValue(1)]
        public int TechnicalEvaluation { get; set; }    

        public string? Note { get; set; }
    }
}
