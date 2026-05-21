using Microsoft.AspNetCore.Mvc;
using Repository;
using Model;

namespace ClassesMetodos.Controllers
{
    public class ProductsController : Controller
    {
        public ProductRepository _productRepository;

        public ProductsController()
        {
            _productRepository = new ProductRepository();
        }

        public IActionResult Index()
        {
            Object objeto = new Object();
            var products = _productRepository.GetAll();

            return View(products);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product is null)
                return View(product);

            _productRepository.Create(product);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var product = _productRepository.GetById(id);
            if (product is null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var product = _productRepository.GetById(id);
            if (product is null)
                return NotFound();

            _productRepository.Delete(product);

            return RedirectToAction(nameof(Index));
        }
    }
}
