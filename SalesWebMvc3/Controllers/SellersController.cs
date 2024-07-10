using Microsoft.AspNetCore.Mvc;

namespace SalesWebMvc3.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
