using Microsoft.AspNetCore.Mvc;
using Repository;
using Model;
using Microsoft.AspNetCore.Http.HttpResults;

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
        public IActionResult Index(string search)
        {
            List<Customer> customers = [];

            if (!string.IsNullOrEmpty(search))
            {
                customers = _customerRepository.GetByName(search);
            }
            else
            {
                customers = _customerRepository.GetAll();
            }
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

            foreach (var a in customer.Addresses)
            _customerRepository.Create(customer);

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

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id <= 0)
                return BadRequest();

            var customer = _customerRepository.GetById(id);

            if(customer is null)
                return NotFound();

            return View(customer);
        }

        [HttpPost]

        public IActionResult Update(int id, Customer customer)
        {
            if (id <= 0)
                return BadRequest();

            if (customer is null)
                return BadRequest();

            if (id != customer.Id)
                return BadRequest();

            _customerRepository.Update(customer);

            return RedirectToAction(nameof(Index));
        }
    }
}
