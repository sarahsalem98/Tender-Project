using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tender.DataAccess.Models
{
    public class TenderAttachment
    {
        public Tender Tender { get; set; }
        [ForeignKey("TenderId")]
        public int TenderId { get; set; }   

        public AttachmentType AttachmentType { get; set; }
        [ForeignKey("AttachmentTypeId")]
        public int AttachmentTypeId { get; set; }

        public string FilePath { get; set; }    
    }
}
