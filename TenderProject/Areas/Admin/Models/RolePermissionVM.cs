namespace TenderProject.Areas.Admin.Models
{
    public class RolePermissionVM
    {
        public int RoleId { get; set; }
       public string Name_Ar { get; set; } 
       public string Name_En { get; set; }    

       public List<PermissionList> PermissionLists { get; set; }   

       // public bool input { get; set; } 

        //public Dictionary<string ,bool> Employees { get; set; }
        //public Dictionary<string, bool> Suppliers { get; set; }
   }
}
