namespace TenderProject.Areas.Admin.Models
{
    public class PermitedPageVM
    {
        public int Id { get; set;}
        public int RoleId { get; set;}  
        public string Action { get; set;}   
        public string Controller { get; set;}   
    }
}
