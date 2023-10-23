using Microsoft.AspNetCore.Mvc;

namespace efCoreApp.Controllers
{
    public class KursKayitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
