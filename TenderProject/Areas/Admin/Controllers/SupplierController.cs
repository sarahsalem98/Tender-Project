using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using TenderProject.Data;
using TenderProject.Models;
using TenderProject.Repository.IRepository;

namespace TenderProject.Areas.Admin.Controllers
{
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
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("getSuppliers")]
        public List<Supplier> getSupplier()
        {
         return _IUnitOfWork.supplier.GetAll().ToList();
        }
    }
}
