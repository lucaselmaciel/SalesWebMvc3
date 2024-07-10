using Microsoft.AspNetCore.Mvc;
using SalesWebMvc3.Models;
using SalesWebMvc3.Services;

namespace SalesWebMvc3.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        
        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            List<Seller> sellersList = _sellerService.FindAll();
            return View(sellersList);
        }
    }
}
