using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PaymentService.Models;
using System.Data;
using System.Diagnostics;

namespace PaymentService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult RedirectToPaymentWindow(string token, int rubles, int kopek, string personId, string comment, int paymentId = 99, int currency = 643)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var url = $"https://qiwi.com/payment/form/{paymentId}?extra['comment']=I%20want%20to%20be%20dirty%20rich&extra['account']={personId}&blocked=account&amountInteger={rubles}&amountFraction={kopek}&currency={currency}";

            return Redirect(url);
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