//using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tender.DataAccess.Models;

namespace TenderProject.Models
{
    public class Supplier:TimeStamp
    {
        public int Id { get; set; }
        public Activity Activity { get; set; }
        [ForeignKey("ActivityId")]
        public int ActivityId { get; set; }

        public string Name { get; set; }    
        public string Email { get; set; }   
        public string Password { get; set; }    
        public string CommercialRegisterationNumber { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName ="Date")]
        public DateTime ReleaseDate { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }

        public string? ConstructorRegisterNumber { get; set; }
        public string? Attachment { get; set; }
        public string? LogoPic { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? BuyingDate { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? WithdrawelDate{  get; set;}

        [DefaultValue(1)]
        public int Status { get; set; }

        public virtual SupplierDelegate SupplierDelegate { get; set; }
        public IList<SupplierBranch> SupplierBranch { get; set; }




    }
}
