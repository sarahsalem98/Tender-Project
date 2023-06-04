using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TenderProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        public IActionResult NoPermission()
        {
            return View();
        }

        [Authorize(AuthenticationSchemes = "Admin_Schema")]
        public IActionResult Index()
        {
            return View();  
        }

    }
}
