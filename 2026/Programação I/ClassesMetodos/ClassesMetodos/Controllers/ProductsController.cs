using Microsoft.AspNetCore.Mvc;
using Repository;
using Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassesMetodos.Controllers
{
    public class ProductsController : Controller
    {
        public ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public ProductsController()
        {
            _productRepository = new ProductRepository();
            _categoryRepository = new CategoryRepository();
        }

        [HttpGet]
        public IActionResult Index(string search)
        {
            var products = string.IsNullOrEmpty(search)
                ? _productRepository.GetAll()
                : _productRepository.GetByName(search);

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoryRepository.GetAll();

            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Create(product);
                return RedirectToAction("Index");
            }

            LoadViewData();

            return View(product);
        }

        private void LoadViewData()
        {
            var categories = _categoryRepository.GetAll();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");
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

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id <= 0)
                return BadRequest();

            var product = _productRepository.GetById(id);

            if (product is null)
                return NotFound();

            if (id != product.Id)
                return BadRequest();

            return View(product);
        }

        [HttpPost]
        public IActionResult Update(int id, Product product)
        {
            if (id <= 0)
                return BadRequest();

            if (product is null)
                return NotFound();

            _productRepository.Update(product);

            return RedirectToAction(nameof(Index));
        }
    }
}
