using Model;
using Repository.VirtualDataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class BaseRepository<T>
    {
        public int GetNextId()
        {
            switch(typeof(T))
            {
                case Type t when t == typeof(Address):
                    return GetNextAddressId();
                case Type t when t == typeof(Customer):
                    return GetNextCustomerId();
                case Type t when t == typeof(Product):
                    return GetNextProductId();
                default:
                    throw new ArgumentException("Invalid type");
            }
        }

        private int GetNextAddressId()
        {
            int maxId = 0;
            foreach (var address in MyData.Addresses)
            {
                if (address.Id > maxId)
                    maxId = address.Id;
            }
            return ++maxId;
        }
        private int GetNextCustomerId()
        {
            int maxId = 0;
            foreach (var customer in MyData.Customers)
            {
                if (customer.Id > maxId)
                    maxId = customer.Id;
            }
            return ++maxId;
        }
        private int GetNextProductId()
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
