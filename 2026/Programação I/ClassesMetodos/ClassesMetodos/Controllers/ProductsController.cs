using Microsoft.AspNetCore.Mvc;
using Repository;
using Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using System.Globalization;

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
            LoadViewData();
            return View(new Product());
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product is null)
                return View(product);

            foreach (var a in product.Products) _productRepository.Create(a);
            _productRepository.Create(product);

            LoadViewData();
            return RedirectToAction(nameof(Index));
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

        [HttpGet]
        public IActionResult ExportTxt()
        {
            var products = _productRepository.GetAll();
            var categories = _categoryRepository.GetAll();

            var sb = new StringBuilder();

            //Cabeçalho
            sb.AppendLine("Id.Name.Price.CategoryId.CategoryName");

            string Escape(string s) => s?.Replace("\"", "\"\"") ?? string.Empty;

            foreach (var p in products)
            {
                var categoryName = categories.FirstOrDefault(c => c.Id == p.CategoryId)?.Name ?? string.Empty;

                var nameField = $"\"{Escape(p.Name)}\"";
                var categoryField = $"\"{Escape(categoryName)}\"";
                var priceField = p.Price.ToString("F2",CultureInfo.InvariantCulture);
                sb.AppendLine()
            }
        }
    }
}
