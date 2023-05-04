using Microsoft.AspNetCore.Mvc;

namespace TenderProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        [Route("Admin/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult postLogin()
        {
            return Ok();

        }
    }
}
