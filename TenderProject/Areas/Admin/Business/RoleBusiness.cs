using Microsoft.IdentityModel.Tokens;
using Tender.DataAccess.Models;
using TenderProject.Areas.Admin.Models;
using TenderProject.Repository.IRepository;

namespace TenderProject.Areas.Admin.Business
{
    public class RoleBusiness
    {
        private readonly IUnitOfWork _IUnitOfWork;
        public RoleBusiness(IUnitOfWork unitOfWork)
        {
            _IUnitOfWork = unitOfWork;

        }
        public List<PermissionList> GetAllPermissions(bool isAdd = true, int? roleId = null)
        {
            List<PermissionList> permissionLists = new List<PermissionList>();
            List<PermissionList> editPermissionList = new List<PermissionList>();

            permissionLists.Add(new PermissionList()
            {
                Controller = "Employee",
                ActionsPermissions = new Dictionary<string, bool>
                {
                        {"Index",false },
                        {"Add",false },
                        {"Edit",false },
                        {"Delete",false }
                }
            });
            permissionLists.Add(new PermissionList()
            {
                Controller = "Suppliers",
                ActionsPermissions = new Dictionary<string, bool>
                {
                        {"Index",false },
                        {"Details",false },
                        {"Activate",false },
                        {"Deactivate",false },
                        {"Decline",false }
                }
            });
            if (isAdd)
            {
                return  permissionLists;

            }
            else
            {
                if (roleId != null)
                {
                    List<Permission> allPermissions = _IUnitOfWork.permission.GetAll(permission => permission.RoleId == roleId);
                    if (allPermissions.IsNullOrEmpty())
                    {
                        return  permissionLists;

                    }
                    else
                    {


                        editPermissionList = this.permissionTransform(allPermissions, permissionLists);


                    }
                }
                return  editPermissionList;





            }





        }


        
        public List<PermissionList> permissionTransform(List<Permission> inputPermissions, List<PermissionList> refPermission)
        {

            var groupPermissions = inputPermissions.GroupBy(p => p.Controller);
            var outputPermissionList = new List<PermissionList>();
            foreach (var groupPermission in groupPermissions)
            {
                Console.WriteLine(groupPermission.Key);
                var dictPermissions = refPermission.FirstOrDefault(p => p.Controller == groupPermission.Key).ActionsPermissions;
                var newDictPermission = new Dictionary<string, bool>();
                var newpermRoleList = new PermissionList()
                {
                    Controller = groupPermission.Key

                };
                foreach (var dictPermission in dictPermissions)
                {
                    bool hasPermission = groupPermission.Any(g => g.Action.ToString().Trim() == dictPermission.Key);
                    newDictPermission[dictPermission.Key] = hasPermission;
                    Console.Write(dictPermission.Key);
                    Console.Write("---");
                    Console.WriteLine(hasPermission);

                }
                newpermRoleList.ActionsPermissions = newDictPermission;
                outputPermissionList.Add(newpermRoleList);

            }

            return outputPermissionList;






        }
    }
}
