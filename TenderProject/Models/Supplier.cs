using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TenderProject.Models
{
    public class Supplier:TimeStamp
    {
        public int Id { get; set; }
        public SupplierActivity SupplierActivity { get; set; }
        [ForeignKey("SupplierActivityId")]
        public int SupplierActivityId { get; set; }

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




    }
}
