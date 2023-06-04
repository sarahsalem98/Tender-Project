using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Collections.Generic;
using TenderProject.Areas.Admin.Models;
using TenderProject.Data;
using TenderProject.Dtos;
using TenderProject.Models;
using TenderProject.Repository.IRepository;
using TenderProject.Types;

namespace TenderProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(AuthenticationSchemes = "Admin_Schema")]
    public class SupplierController : Controller
    {
        private readonly IUnitOfWork _IUnitOfWork;
        public SupplierController
            (
            IUnitOfWork unitOfWork

            )
        {
            _IUnitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            List<(int, string)> supplierListEnums = Enum.GetValues(typeof(SupplierStatusEnum))
                                                                .Cast<SupplierStatusEnum>()
                                                                .Select(e => ((int)e, e.ToString()))
                                                                .ToList();
            ViewBag.Cities = _IUnitOfWork.city.GetAll(includeProperties: "Government").ToList();
            ViewBag.SupplierStatuses = supplierListEnums;
            return View();
        }

        public ResultVM<List<Supplier>> AllSuppliers(SupplierSearch search)
        {


            List<Supplier> suppliers = _IUnitOfWork.supplier.GetAll(includeProperties: "Activity");

            var result = new ResultVM<List<Supplier>>();
            if (search.IsSearch)
            {
                if (!String.IsNullOrEmpty(search.Name))
                {
                    suppliers = suppliers.FindAll(s=>s.Name.Contains(search.Name));


                }
                 if (!String.IsNullOrEmpty(search.Email))
                {
                    suppliers = suppliers.FindAll(s => s.Email.Contains(search.Email));
                }
                 if (!String.IsNullOrEmpty(search.CRN))
                {
                     suppliers = suppliers.FindAll(s => s.CommercialRegisterationNumber.Contains(search.CRN));
                }
                 if (search.Status != 0)
                {
                    suppliers = suppliers.FindAll(s => s.Status == search.Status).ToList();
                }
           
                result = new ResultVM<List<Supplier>>()
                {
                    Data = suppliers,
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
                result = new ResultVM<List<Supplier>>()
                {
                    Data = _IUnitOfWork.supplier.GetAll().ToList(),
                    Status = Status.Success,
                    ServerInfo = new ServerInfo()
                    {
                        CustomStatusCode = CustomStatusCodes.Success,
                        Message = "successfully"
                    }
                };
            }

            return result;

        }

     
       
  
        public IActionResult Activate(int id,string returnUrl)
        {

            return setStatus(id, ((int)SupplierStatusEnum.Activated), returnUrl);

        }
        public IActionResult Deactivate(int id, string returnUrl)
        {
            return setStatus(id, ((int)SupplierStatusEnum.Deactivated), returnUrl);

        }
        public IActionResult Decline(int id, string returnUrl)
        {
            return setStatus(id, ((int)SupplierStatusEnum.Declined), returnUrl);

        }

        public IActionResult Details(int id)
        {
            if (id != 0)
            {
              Supplier supplier = _IUnitOfWork.supplier.GetFirstOrDefault(s => s.Id == id
              ,includeProperties: "Activity,SupplierDelegate,SupplierBranch.City,SupplierBranch.Government"
              );
            return View(supplier);
            }
            else
            {
                return BadRequest();
            }
        }







        [NonAction]
        public IActionResult setStatus(int id,int status, string returnUrl)
        {
            if (id != 0)
            {
                Supplier supplier = _IUnitOfWork.supplier.GetFirstOrDefault(s => s.Id == id);
                if (supplier != null)
                {
                    supplier.Status = status;
                    _IUnitOfWork.supplier.update(supplier);
                    _IUnitOfWork.save();
                    return Redirect(returnUrl);
                }
                else
                {
                    return BadRequest("no supplier found with this provided id");
                }
            }
            else
            {
                return BadRequest("the id you passed is null");
            }

        }
    }
}
