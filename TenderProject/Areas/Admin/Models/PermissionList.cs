namespace TenderProject.Areas.Admin.Models
{
    public class PermissionList
    {
        public string Controller { get; set;}   
       
         public Dictionary<string, bool> ActionsPermissions { get;set;}

    }
}
