using System;
using System.Collections.Generic;
using System.Text;
using Repository;
using Repository.VirtualDataBase;
using Model;

namespace Repository
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public List<Category> GetAll()
        {
            return MyData.Categories;
        }
    }
}
