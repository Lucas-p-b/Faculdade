using ExVet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SaleOrder;

namespace ExVet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            SaleOrder.Customer c1 = new SaleOrder.Customer();
            c1.Id = 1;
            c1.Name = "Frodo";
            c1.BirthDate = new DateTime(2007, 01, 22);

            Console.WriteLine(c1.ToString());

            Console.WriteLine(SaleOrder.Customer.InstanceCount);

            SaleOrder.Customer c2 = new SaleOrder.Customer()
            {
                Id = 2,
                Name = "Aragorn",
                BirthDate = new DateTime(1822, 09, 21)
            };

            Console.WriteLine(c2.ToString());

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
