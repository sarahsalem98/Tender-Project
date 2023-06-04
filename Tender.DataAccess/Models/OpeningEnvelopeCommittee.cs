using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderProject.Models;

namespace Tender.DataAccess.Models
{
    public class OpeningEnvelopeCommittee:TimeStamp
    {
        public int Id { get; set; }
        public string? Name_Ar { get; set; }
        public string Name_En { get; set; }
    }
}
