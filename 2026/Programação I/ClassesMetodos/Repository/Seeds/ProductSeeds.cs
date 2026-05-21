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

            if (MyData.Products.Count < 1) ;
            {

                Product p1 = new Product();
                p1.Id = 1;
                p1.Name = "Cachaça";
                p1.Price = 5;

                MyData.Products.Add(p1);

            }
        }
    }
}
