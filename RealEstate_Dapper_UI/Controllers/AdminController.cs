using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            ViewData["title"] = "Admin Panel";
            return View();
        }
    }
}
