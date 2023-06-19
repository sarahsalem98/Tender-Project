namespace TenderProject.Areas.Admin.Models
{
    public class TenderVM
    {
    }
    public class SearchTender
    {
       public bool IsSearch { get; set; }
       public int TenderFilter { get; set; }
       
       public int Type { get; set; }  
       
       public int Status { get; set; }
        public string ?Name { get; set; }      
        public string ?CreatedBy { get; set; }
        public string ?ApprovedBy { get; set; }

    }
}
