using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderProject.Models;

namespace Tender.DataAccess.Models
{
    public class TenderPayment
    {

        //no time stamp here as this is assocciated with tender when the it updates the tender is updated
        public int Id { get; set; }

        public Tender Tender { get; set; }
        [ForeignKey("TenderId")]
        public int TenderId { get; set; }


        public PaymentType PaymentType{ get; set; }
        [ForeignKey("PaymentTypeId")]
        public int? PaymentTypeId { get; set; }


        public int Cost { get; set; }
    }
}
