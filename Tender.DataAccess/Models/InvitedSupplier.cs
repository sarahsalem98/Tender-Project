﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderProject.Models;

namespace Tender.DataAccess.Models
{
    public class InvitedSupplier:TimeStamp
    {
        public Supplier Supplier { get; set; }
        [ForeignKey("SupplierId")]
        public int SupplierId { get; set; }

        public Tender Tender { get; set; }
        [ForeignKey("TenderId")]
        public int TenderId { get; set; }
        [DefaultValue(1)]
        public int InvitationStatus { get; set; }
    }
}
