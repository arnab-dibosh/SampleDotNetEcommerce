using DotNetEcommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetEcommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Checkout() {
            List<Product> products = new List<Product>();
            string productListFromSession = HttpContext.Session.GetString(Constants.ItemList);

            if (!string.IsNullOrEmpty(productListFromSession))
                products = JsonConvert.DeserializeObject<List<Product>>(productListFromSession);
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitOrder([FromBody] Order order) {
            try {

                Thread.Sleep(10000);
            }
            catch (Exception ex) {
                return BadRequest(new {
                    errorMessage = ex.Message
                });
            }
            return Json(new {
                Messase = "Success"
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] Product product) {
            try {

                List<Product> products = new List<Product>();
                string productListFromSession = HttpContext.Session.GetString(Constants.ItemList);
                if (!string.IsNullOrEmpty(productListFromSession))
                    products = JsonConvert.DeserializeObject<List<Product>>(productListFromSession);

                products.Add(product);
                HttpContext.Session.SetString(Constants.ItemList, JsonConvert.SerializeObject(products));
            }
            catch (Exception ex) {
                return BadRequest(new {
                    errorMessage = ex.Message
                });
            }
            return Json(new {
                Messase = "Success"
            });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


}
