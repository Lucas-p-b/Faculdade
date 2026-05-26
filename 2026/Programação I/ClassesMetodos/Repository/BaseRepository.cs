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
    }
}
