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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            DateTime dateTime = seller.BirthDate;
            if (dateTime.Kind == DateTimeKind.Unspecified)
            {
                dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            }
            dateTime = dateTime.ToUniversalTime();
            seller.BirthDate = dateTime;
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
