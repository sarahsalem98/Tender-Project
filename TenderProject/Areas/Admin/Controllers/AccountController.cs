using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using TenderProject.Areas.Admin.Business;
using TenderProject.Areas.Admin.Models;
using TenderProject.Helpers;
using TenderProject.Models;
using TenderProject.Repository.IRepository;

namespace TenderProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly Auth _auth;
        private readonly IHttpContextAccessor _IhttpContextAccessor;
        private readonly AccountBusiness _accountBusiness;

       public AccountController(
           IUnitOfWork unitOfWork,
           Auth auth,
           IHttpContextAccessor httpContextAccessor,
           AccountBusiness accountBusiness
           
           )
        {
            _IUnitOfWork=unitOfWork;
            _auth=auth;
            _IhttpContextAccessor = httpContextAccessor;
            _accountBusiness=accountBusiness;
        }
        public IActionResult Login()
        {
         
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Login(LoginVM loginVM)
        {

            if (_IUnitOfWork.employee.GetAll().Any())
            {
                Employee employee=_IUnitOfWork.employee.GetFirstOrDefault(e=>e.Email==loginVM.Email, "Role.Permissions");
               
                if (employee!=null)
                {
                    if (_auth.ValidatePassword(employee.Password, loginVM.Password))
                    {
                        var permissionJson = JsonConvert.SerializeObject(employee.Role.Permissions, new JsonSerializerSettings
                        {
                            ReferenceLoopHandling= ReferenceLoopHandling.Ignore 
                        });
                        if (_IhttpContextAccessor.HttpContext.Request.Cookies.ContainsKey("Admin"))
                        {
                            _IhttpContextAccessor.HttpContext.SignOutAsync("Admin_Schema");
                        }
                        await _IhttpContextAccessor.HttpContext.SignInAsync("Admin_Schema"
                            , new ClaimsPrincipal(new ClaimsIdentity(
                                new Claim[]
                                {
                                    new Claim(ClaimTypes.Name,employee.Name),
                                    new Claim(ClaimTypes.Email,employee.Email),
                                    new Claim(ClaimTypes.NameIdentifier,employee.Id.ToString()),
                                    new Claim(ClaimTypes.Role,employee.Role.Name_En),
                                    new Claim("RoleId",employee.RoleId.ToString()),
                                    new Claim("Permissions",permissionJson)
                                }, "Admin_Schema"
                                )),new AuthenticationProperties { IsPersistent=false}) ;
                      
                        return RedirectToAction("index","home");
                    }
                    else
                    {
                        return BadRequest("password is not correct");
                    }
                }
                else
                {
                    return BadRequest("this email is not registed in the system make sure to ask the admin");
                }

            }
            else
            {
                if (!_IUnitOfWork.role.GetAll().Any())
                {
                    Role newRole = new Role
                    {
                        Name_Ar="الادمن الاكبر",
                        Name_En= "SuperAdmin",
                        UpdatedAt=DateTime.Now, 
                        CreatedAt=DateTime.Now
                    };
                    _IUnitOfWork.role.Add(newRole);
                    _IUnitOfWork.save();
                }
                Employee newEmployee = new Employee
                {
                    Email = loginVM.Email,
                    Password = _auth.HashPassword(loginVM.Password),
                    Name = loginVM.Email.Split("@")[0],
                    Role = _IUnitOfWork.role.GetFirstOrDefault(r => r.Name_En.Contains("SuperAdmin")),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                


                };
                _IUnitOfWork.employee.Add(newEmployee);
                _IUnitOfWork.save();
                if (_IhttpContextAccessor.HttpContext.Request.Cookies.ContainsKey("Admin"))
                {
                    _IhttpContextAccessor.HttpContext.SignOutAsync("Admin_Schema");
                }
                
                await _IhttpContextAccessor.HttpContext.SignInAsync("Admin_Schema"
                           , new ClaimsPrincipal(new ClaimsIdentity(
                               new Claim[]
                               {
                                    new Claim(ClaimTypes.Name,newEmployee.Name),
                                    new Claim(ClaimTypes.Email,newEmployee.Email),
                                    new Claim(ClaimTypes.NameIdentifier,newEmployee.Id.ToString()),
                                    new Claim(ClaimTypes.Role,newEmployee.Role.Name_En),
                                      new Claim("RoleId",newEmployee.RoleId.ToString()),
                                    new Claim("RoleId",newEmployee.RoleId.ToString())
                               }
                               )), new AuthenticationProperties { IsPersistent = false });

                _IhttpContextAccessor.HttpContext.Session.SetObjectAsJson("user_inf_session", _accountBusiness.SetUserInfInSessionForm(newEmployee));
                return RedirectToAction("index", "home");
            }

          

        }
        public IActionResult Logout()
        {
            if (_IhttpContextAccessor.HttpContext.Request.Cookies.ContainsKey("Admin"))
            {
                _IhttpContextAccessor.HttpContext.SignOutAsync("Admin_Schema");
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return BadRequest("there is no authentication session to logout from");
            }


           
        }
    }
}
