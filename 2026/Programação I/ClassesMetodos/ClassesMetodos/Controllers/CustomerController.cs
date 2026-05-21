using Microsoft.AspNetCore.Mvc;
using Repository;
using Model;

namespace ClassesMetodos.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerRepository _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            Object objeto = new Object();
            var customers = _customerRepository.GetAll();

            return View(customers);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View(new Customer());
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (customer is null)
                return View(customer);

            _customerRepository.Create(customer);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id <= 0)
                return BadRequest();

            var customer = _customerRepository.GetById(id);
            if (customer is null)
                return NotFound();

            return View(customer);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            if(id<=0)
                return BadRequest();

            var customer = _customerRepository.GetById(id);
            if (customer is null)
                return NotFound();

            _customerRepository.Delete(customer);

            return RedirectToAction(nameof(Index));
        }
    }
}
