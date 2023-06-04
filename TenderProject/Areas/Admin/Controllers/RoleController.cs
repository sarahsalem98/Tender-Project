using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using Tender.DataAccess.Models;
using TenderProject.Areas.Admin.Business;
using TenderProject.Areas.Admin.Models;
using TenderProject.Dtos;
using TenderProject.Helpers;
using TenderProject.Models;
using TenderProject.Repository.IRepository;

namespace TenderProject.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(AuthenticationSchemes = "Admin_Schema")]
    public class RoleController : Controller
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly RoleBusiness _roleBusiness;
        public RoleController(
            IUnitOfWork unitOfWork,
            RoleBusiness roleBusiness,
            IHttpContextAccessor httpContextAccessor

            )
        {
            _roleBusiness = roleBusiness;
            _IUnitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;

        }
        // GET: RoleController
        public ActionResult Index()
        {
            ViewBag.Roles = _IUnitOfWork.role.GetAll(includeProperties: "Employees");
            // ViewBag.UserRolesCount = _IUnitOfWork.role.GetAll(includeProperties: "Employees").GroupBy(r => r.Employees.Select(r=>r.Id)).Select(r => new {roleId=r.Key,count=r.Count()});
            return View();
        }

        // GET: RoleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoleController/Create
        public ActionResult Create()
        {
            ViewBag.RolePermissions= _roleBusiness.GetAllPermissions(true);
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        //    [ValidateAntiForgeryToken]
        public ResultVM<string> AddEditRole(RolePermissionVM dataModel)
        {
            var authUserRoleId = _httpContextAccessor.HttpContext.User.FindFirst(c => c.Type == "RoleId").Value;
            var result = new ResultVM<string>();
            try
            {
                
                Role role = new Role()
                {
                    Name_Ar = dataModel.Name_Ar,
                    Name_En = dataModel.Name_En,
             
                };
                if (dataModel.RoleId != 0)
                {
                    role.Id = dataModel.RoleId;
                    role.UpdatedAt = DateTime.Now;
                    role.UpdatedBY = this.User.GetAuthenticatedUserString();

                    _IUnitOfWork.role.Update(role);
                    _IUnitOfWork.permission.RemoveRange(_IUnitOfWork.permission.GetAll(p => p.RoleId == dataModel.RoleId));
                    //if (dataModel.RoleId.ToString() == authUserRoleId)
                    //{
                    //    _httpContextAccessor.HttpContext.SignOutAsync("Admin_Schema");

                    // }
                }
                else
                {


                    role.CreatedAt = DateTime.Now;
                    role.UpdatedAt = DateTime.Now;
                    role.CreatedBY = this.User.GetAuthenticatedUserString();
                    _IUnitOfWork.role.Add(role);

                }
                    foreach (var permission in dataModel.PermissionLists)
                    {
                        var controllerName = permission.Controller;
                        foreach (var action in permission.ActionsPermissions)
                        {
                            if (action.Value == true)
                            {
                                _IUnitOfWork.permission.Add(new Permission
                                {
                                    Controller = controllerName,
                                    Action = action.Key,
                                    Role = role,
                                    //CreatedAt =  DateTime.Now,
                                    //UpdatedAt = DateTime.Now,
                                    //CreatedBY = this.User.GetAuthenticatedUserString()
                                });
                            }

                        }

                    }

                    _IUnitOfWork.save();
                    result = new ResultVM<string>
                    {
                        Data = "1",
                        ServerInfo = new ServerInfo
                        {
                            CustomStatusCode = CustomStatusCodes.Success,
                            Message = "the permission is successfully created",
                        },
                        Status = Status.Success
                    };


                    return result;

                
               
            }
            catch
            {
                result = new ResultVM<string>
                {
                    Data = "0",
                    ServerInfo = new ServerInfo
                    {
                        CustomStatusCode = CustomStatusCodes.BadRequest,
                        Message = "there is something wrong",
                    },
                    Status = Status.Error
                };
                return result;
            }
        }

        // GET: RoleController/Edit/5
        public ActionResult Edit(int id)
        {
            Role savedRole = _IUnitOfWork.role.GetFirstOrDefault(r => r.Id == id);

            ViewBag.roleNameArabic = savedRole.Name_Ar;
            ViewBag.roleNameEnglish = savedRole.Name_En;
            ViewBag.roleId = savedRole.Id;
            ViewBag.RolePermissions= _roleBusiness.GetAllPermissions(false, id);
            return View();
        }

        // POST: RoleController/Edit/5
        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

     
        // POST: RoleController/Delete/5
        [HttpPost]
     //   [ValidateAntiForgeryToken]
        public ResultVM<string> Delete(int id)
        {
            var result = new ResultVM<string>();
            try
            {
            Role savedRole = _IUnitOfWork.role.GetFirstOrDefault(r => r.Id == id);
            List<Permission> Savedpermissions = _IUnitOfWork.permission.GetAll(p => p.RoleId == id);

                if (savedRole.Employees?.Count()>0)
                {
                    return result = new ResultVM<string>()
                    {
                        Status = Status.Error,
                        Data = "0",
                        ServerInfo = new ServerInfo()
                        {
                            CustomStatusCode = CustomStatusCodes.BadRequest,
                            Message = "the role and its permission are not deleted ,something went wrong"
                        }

                    };

                }
                if (Savedpermissions != null)
                {
                    _IUnitOfWork.permission.RemoveRange(Savedpermissions);
                    _IUnitOfWork.save();
                    if (savedRole != null)
                    {

                        _IUnitOfWork.role.Remove(savedRole);
                        _IUnitOfWork.save();
                    }

                    result = new ResultVM<string>()
                    {
                        Status = Status.Success,
                        Data = "1",
                        ServerInfo = new ServerInfo()
                        {
                            CustomStatusCode = CustomStatusCodes.Success,
                            Message = "the role and its permission is deleted successfully"
                        }
                    };
                }
               
            }
            catch
            {
                result = new ResultVM<string>()
                {
                    Status = Status.Error,
                    Data = "0",
                    ServerInfo = new ServerInfo()
                    {
                        CustomStatusCode = CustomStatusCodes.BadRequest,
                        Message = "the role and its permission are not deleted ,something went wrong"
                    }
                };
            }
            return result;
        }

       
       

    }
}



//sara code

//if (roleId != null)
//{
//    List<Permission> allPermissions = _IUnitOfWork.permission.GetAll(permission => permission.RoleId == roleId);
//    var groupPermissions = allPermissions.GroupBy(p => p.Controller);
//    foreach (var groupPermission in groupPermissions)
//    {
//        Dictionary<string, bool> editActionPermissions = new Dictionary<string, bool>();
//        foreach (var permissionlist in permissionLists)

//        {
//            foreach (var action in permissionlist.ActionsPermissions)
//            {
//                foreach (var permission in groupPermission)
//                {
//                    if (permission.Controller == permissionlist.Controller)
//                    {


//                        if (String.Equals(action.Key.ToString().Trim(), permission.Action.ToString().Trim()))
//                        {

//                            editActionPermissions[action.Key] = true;
//                            break;


//                        }
//                        else
//                        {
//                            editActionPermissions[action.Key] = false;
//                        }







//                    }

//                }


//            }
//        }

//        editPermissionList.Add(new PermissionList()
//        {
//            Controller = groupPermission.Key,
//            ActionsPermissions = editActionPermissions

//        }); ;

//    }




