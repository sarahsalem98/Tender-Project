using Tender.DataAccess.Models;

namespace TenderProject.Areas.Admin.Models
{
    public class SupplierSearch
    {         
           public bool IsSearch { get; set; }
           public string Name { get; set; }
           public string Email { get; set; }  

           public string CRN { get;set; }
           public int CityId { get; set; }
           public int  Status { get; set; }
    }
    public class SupplierVM
    {
        //public int Id { get; set; }
        //public string SupplierName { get; set; }    
        //public string SupplierEmail { get; set; }   
        //public string SupplierActivity { get; set; }
        //public DateTime BuyingDate { get; set; }
        //public DateTime WithdrawelDate { get; set; }
        //public DateTime ReleaseDate { get; set; }
        //public string CommertialRegisterationNumber { get; set; }

        //public SupplierDelegate SupplierDelegate { get; set; }  
        //public IList<SupplierBranch> SupplierBranches { get; set; }


        
    }

}
