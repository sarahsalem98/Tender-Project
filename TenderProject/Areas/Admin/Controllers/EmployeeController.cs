using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TenderProject.Areas.Admin.Models;
using TenderProject.Dtos;
using TenderProject.Helpers;
using TenderProject.Models;
using TenderProject.Repository.IRepository;

namespace TenderProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _IUnitOfWork;
        private readonly Auth _auth;
        public EmployeeController(
            IUnitOfWork unitOfWork
           , Auth auth
            )
        {
            _IUnitOfWork = unitOfWork;
            _auth = auth;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            return View();
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
        public ResultVM<string> Create(EmployeeVM employeeVM)
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

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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

        public ResultVM<List<Employee>> AllEmployees()
        {
            List<Employee> employees = _IUnitOfWork.employee.GetAll(includeProperties: "Role");
            var result = new ResultVM<List<Employee>>
            {
                Data = employees,
                ServerInfo = new ServerInfo()
                {
                    CustomStatusCode = CustomStatusCodes.Success,
                    Message = "success"
                },
                Status = Status.Success
            };
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
