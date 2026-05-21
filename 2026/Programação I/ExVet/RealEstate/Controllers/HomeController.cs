using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using System.Diagnostics;
using RealEstateCatalog;

namespace RealEstate.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            RealEstateCatalog.Home Home1 = new RealEstateCatalog.Home();
            Home1.Id = 1;
            Home1.Address = "Address1";
            Home1.Size = 100;
            Home1.Price = 1000;
            Home1.Status = "Sale";

            RealEstateCatalog.Home Home2 = new RealEstateCatalog.Home();
            Home2.Id = 2;
            Home2.Address = "Address2";
            Home2.Size = 200;
            Home2.Price = 2000;
            Home2.Status = "Rent";

            RealEstateCatalog.Home Home3 = new RealEstateCatalog.Home();
            Home3.Id = 3;
            Home3.Address = "Address3";
            Home3.Size = 300;
            Home3.Price = 3000;
            Home3.Status = "Rent";

            RealEstateCatalog.Home Home4 = new RealEstateCatalog.Home();
            Home4.Id = 4;
            Home4.Address = "Address4";
            Home4.Size = 400;
            Home4.Price = 4000;
            Home4.Status = "Sale";

            RealEstateCatalog.Home Home5 = new RealEstateCatalog.Home();
            Home5.Id = 5;
            Home5.Address = "Address5";
            Home5.Size = 500;
            Home5.Price = 5000;
            Home5.Status = "Rent";

            List<Home> Homes = new List<Home>();
            Homes.Add(Home1);
            Homes.Add(Home2);
            Homes.Add(Home3);
            Homes.Add(Home4);
            Homes.Add(Home5);

            return View(Homes);
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
