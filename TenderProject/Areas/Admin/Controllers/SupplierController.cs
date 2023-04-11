using Microsoft.AspNetCore.Mvc;
using TenderProject.Data;
using TenderProject.Models;

namespace TenderProject.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SupplierController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("getSuppliers")]
        public List<Supplier> getSupplier()
        {
            return _db.Suppliers.ToList();
        }
    }
}
