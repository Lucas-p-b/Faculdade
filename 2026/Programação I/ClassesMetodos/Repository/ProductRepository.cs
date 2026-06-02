using Model;
using Repository.VirtualDataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Repository
{
    public class ProductRepository : BaseRepository<Product>
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

        public List<Product> GetByCategoryId(int categoryId)
        {
            List<Product> products = [];

            foreach (var p in MyData.Products)
            {
                if (p.CategoryId == categoryId)
                {
                    products.Add(p);
                }
            }
            return products;
        }

        public List<Product> GetAll()
        {
            return MyData.Products;
        }
    }
}
