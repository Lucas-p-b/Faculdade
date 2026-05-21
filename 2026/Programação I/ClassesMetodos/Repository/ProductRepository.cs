using Model;
using Repository.VirtualDataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ProductRepository
    {
        public void Create(Product product)
        {
            product.Id = GetNextId();
            MyData.Products.Add(product);
        }

        public void Delete(Product product)
        {
            MyData.Products.Remove(product);
        }

        public void Update(Product product)
        {
            var _product = GetById(product.Id);
            _product.Name = _product.Name;
            _product.Price = _product.Price;
        }

        public Product GetById(int Id)
        {
            var product = MyData.Products.FirstOrDefault(x => x.Id == Id);

            if (product is null) return null;

            return product;
        }

        public List<Product> GetByName(string Name)
        {
            List<Product> products = [];

            foreach (var c in MyData.Products)
            {
                if (c.Name.ToLower().Contains(Name.ToLower()))
                {
                    products.Add(c);
                }
            }
            return products;
        }

        public List<Product> GetAll()
        {
            return MyData.Products;
        }

        private int GetNextId()
        {

            int maxId = 0;
            foreach (var product in MyData.Products)
            {
                if (product.Id > maxId)
                    maxId = product.Id;
            }
            return ++maxId;
        }
    }
}
