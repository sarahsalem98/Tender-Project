using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderProject.Models;

namespace Tender.DataAccess.Models
{
    public class SupplierPayment:TimeStamp
    {
        public int Id { get; set; }
        public Supplier Supplier { get; set; }
        [ForeignKey("SupplierId")]
        public int SupplierId { get; set; }
        public TenderPayment TenderPayment{ get; set; }
        [ForeignKey("TenderPaymentId")]
        public int TenderPaymentId { get; set; }

        public int Status { get; set; }

        public string Method { get; set; }

    }
}
