using Model;
using Repository.VirtualDataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Seeds
{
    public static class CategorySeeds
    {
        public static void seed()
        {
            MyData.Categories.AddRange(new List<Category>
            {
                new Category { Id = 1, Name = "Eletônicos" },
                new Category { Id = 2, Name = "Roupas" },
                new Category { Id = 3, Name = "Alimentos" }
            });
        }
    }
}
