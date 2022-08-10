using Microsoft.AspNetCore.Mvc;
using Sample.Models;
using System.Diagnostics;
using Pargoon.ZarinPal;
namespace Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string key = "3c3eb226-6e1b-485c-bcab-c94f33dbeefa";
        private readonly string callBackUrl = "http://localhost:5112/home/verification";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ZarinPalCleint zarinpal = ZarinPalCleint.Get();
            PaymentRequest pr = new PaymentRequest(key, 50000, callBackUrl, "this is a test");

            var res = zarinpal.InvokePaymentRequest(pr);
            if (res.Status == 100)
            {
                return Redirect(res.PaymentURL);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}