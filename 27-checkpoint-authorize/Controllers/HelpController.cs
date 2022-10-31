using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopHRM.Controllers
{
    public class HelpController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
