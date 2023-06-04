using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly Auth _auth;
        private readonly UserVM userInfo=new UserVM();
        private readonly IHttpContextAccessor _IhttpContextAccessor;
        public EmployeeController(
            IUnitOfWork unitOfWork
           , Auth auth
            , IHttpContextAccessor httpContextAccessor  
            )
        {
            _IUnitOfWork = unitOfWork;
            _auth = auth;
            _IhttpContextAccessor= httpContextAccessor;
            userInfo = _IhttpContextAccessor.HttpContext.Session.GetObjectFromJson<UserVM>("user_inf_session");
        }

        // GET: EmployeeController
   
        public ActionResult Index()
        {
            if (GeneralStaticBusiness.CheckPermitedPages("Index", "Employee",_IhttpContextAccessor))
            {
            ViewBag.Roles = _IUnitOfWork.role.GetAll();
          
            return View();

            }
            return RedirectToAction("noPermission", "home", new { area = "admin" });
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            setViewBags();
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        //   [ValidateAntiForgeryToken]
        public ResultVM<string> AddEditEmployee(EmployeeVM employeeVM)
        {
           
            var result = new ResultVM<string>();

            if (ModelState.IsValid)
            {
                Employee employee = new Employee()
                {
                    Name = employeeVM.Name,
                    Email = employeeVM.Email,
                    PhoneNumber = employeeVM.PhoneNumber,
                    Password = _auth.HashPassword(employeeVM.Password),
                    RoleId = employeeVM.RoleId,
                    UpdatedAt = DateTime.Now,
                    UpdatedBY=null,
                    CreatedBY="ahmed"

                };
                #region Edit class
                if (employeeVM.Id != 0)
                {
                    employee.Id = employeeVM.Id;
                    _IUnitOfWork.employee.Update(employee);
                    _IUnitOfWork.save();
                    result = new ResultVM<string>()
                    {
                        Data = "1",
                        ServerInfo = new ServerInfo()
                        {
                            CustomStatusCode = CustomStatusCodes.Success,
                            Message = "success"

                        },
                        Status = Status.Success
                    };
                }
                #endregion
                #region add employee
                else
                {
                    employee.CreatedAt = DateTime.Now;
                    _IUnitOfWork.employee.Add(employee);
                    _IUnitOfWork.save();
                    result = new ResultVM<string>()
                    {
                        Data = "1",
                        ServerInfo = new ServerInfo()
                        {
                            CustomStatusCode = CustomStatusCodes.Success,
                            Message = "success"

                        },
                        Status = Status.Success
                    };
                }
                #endregion


            }
            else
            {
                result = new ResultVM<string>()
                {
                    Data = "0",
                    ServerInfo = new ServerInfo()
                    {
                        CustomStatusCode = CustomStatusCodes.notValid,
                        Message = "error"

                    },
                    Status = Status.notValid
                };

            }
            return result;


        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = _IUnitOfWork.employee.GetFirstOrDefault(e => e.Id == id);
            var employeeVM = new EmployeeVM
            {
                Id = employee.Id,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber ?? " ",
                RoleId = employee.RoleId ?? 0,
                Name = employee.Name ?? " "
            };
            setViewBags();
            return View(employeeVM);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

      

        // POST: EmployeeController/Delete/5
        [HttpPost]
       
        public ResultVM<string> Delete(int id)
        {
            var result = new ResultVM<string>(); 
           Employee employee= _IUnitOfWork.employee.GetFirstOrDefault(e=>e.Id==id);
            if (employee != null)
            {
                _IUnitOfWork.employee.Remove(employee);
                _IUnitOfWork.save();
                result = new ResultVM<string>
                {
                    Data="1",
                    ServerInfo = new ServerInfo()
                    {
                        CustomStatusCode = CustomStatusCodes.Success,
                        Message = "success"

                    },
                    Status =Status.Success

                };

            }else
            {
                result = new ResultVM<string>
                {
                    Data = "0",
                    ServerInfo = new ServerInfo()
                    {
                        CustomStatusCode = CustomStatusCodes.NotFound,
                        Message = "error"

                    },
                    Status = Status.NotFound

                };

            }
            return result;
        }


        public ResultVM<List<Employee>> AllEmployees(EmployeeSearch search)
        {

            List<Employee> employees = _IUnitOfWork.employee.GetAll(includeProperties: "Role");


            var result = new ResultVM<List<Employee>>();
            if (search.IsSearch)
            {
                if (search.Id!=0)
                {
                    employees = employees.FindAll(e => e.Id==search.Id);


                }
                if (!String.IsNullOrEmpty(search.Name))
                {
                    employees = employees.FindAll(e => e.Name.Contains(search.Name));


                }
                if (!String.IsNullOrEmpty(search.Email))
                {
                    employees = employees.FindAll(e => e.Email.Contains(search.Email));
                }
                if (!String.IsNullOrEmpty(search.PhoneNumber))
                {
                    employees = employees.FindAll(e => e.PhoneNumber.Contains(search.PhoneNumber));
                }
                if (search.RoleId != 0)
                {
                    employees = employees.FindAll(s => s.RoleId == search.RoleId).ToList();
                }

                result = new ResultVM<List<Employee>>()
                {
                    Data = employees,
                    Status = Status.Success,
                    ServerInfo = new ServerInfo()
                    {
                        CustomStatusCode = CustomStatusCodes.Success,
                        Message = "successfully"
                    }
                };

            }
            else
            {


                result = new ResultVM<List<Employee>>
                {
                    Data = employees,
                    ServerInfo = new ServerInfo()
                    {
                        CustomStatusCode = CustomStatusCodes.Success,
                        Message = "success"
                    },
                    Status = Status.Success
                };
            }
            return result;




        }
        [NonAction]
        public void setViewBags()
        {
            var rolesList = _IUnitOfWork.role.GetAll();
            ViewBag.roles = rolesList;
        }
    }
}
