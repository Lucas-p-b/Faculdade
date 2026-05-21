using Model;
using Repository.VirtualDataBase;

namespace Repository
{
    public class CustomerRepository
    {
        public void Create(Customer customer)
        {
            customer.Id = GetNextId();
            MyData.Customers.Add(customer);
        }

        public void Delete(Customer customer)
        {
            MyData.Customers.Remove(customer);
        }

        public void Update(Customer customer)
        {
            var _customer = GetById(customer.Id);
            _customer.FirstName = _customer.FirstName;
            _customer.LastName = _customer.LastName;
            _customer.Email = _customer.Email;
            _customer.Phone = _customer.Phone;
        }

        public Customer GetById(int Id)
        {
            var customer = MyData.Customers.FirstOrDefault(x => x.Id == Id);

            if (customer is null) return null;

            return customer;
        }

        public List<Customer> GetByName(string Name)
        {
            List<Customer> customers = [];

            foreach (var c in MyData.Customers)
            {
                if (c.FirstName.ToLower().Contains(Name.ToLower()) || c.LastName.ToLower().Contains(Name.ToLower()))
                {
                    customers.Add(c);
                }
            }
            return customers;
        }

        public List<Customer> GetAll()
        {
            return MyData.Customers;
        }

        private int GetNextId()
        {
            //return MyData.Customers.Max(x => x.Id);

            int maxId = 0;
            foreach(var customer in MyData.Customers)
            {
                if (customer.Id > maxId)
                    maxId = customer.Id;
            }
            return ++maxId;
        }
    }
}
