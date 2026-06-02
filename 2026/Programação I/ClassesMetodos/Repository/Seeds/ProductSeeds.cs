using Model;
using Repository.VirtualDataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Seeds
{
    public static class ProductSeeds
    {
        public static void Seed()
        {
            MyData.Products.AddRange(new List<Product>
                {
                new Product
                {
                    Id = 1,
                    Name = "Cachaça",
                    Price = 5,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 2,
                    Name = "Pão",
                    Price = 10,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 3,
                    Name = "Camiseta",
                    Price = 20,
                    CategoryId = 2
                },
            });
        }
    }
}
