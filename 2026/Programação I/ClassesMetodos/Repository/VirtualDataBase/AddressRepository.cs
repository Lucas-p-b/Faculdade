using Model;
using System;
using System.Collections.Generic;
using System.Text;
using Repository.VirtualDataBase;

namespace Repository.VirtualDataBase
{
    public class AddressRepository : BaseRepository<Address>
    {
        public void Create(Address address)
        {
            address.Id = GetNextId();
            MyData.Addresses.Add(address);
        }

        private int GetNextId()
        {

            int maxId = 0;
            foreach (var address in MyData.Addresses)
            {
                if (address.Id > maxId)
                    maxId = address.Id;
            }
            return ++maxId;
        }

        public void Delete(Address address)
        {
            MyData.Addresses.Remove(address);
        }

        public void Update (Address address)
        {
            var _address = GetById(address.Id);
            _address.Street = address.Street;
            _address.City = address.City;
            _address.FederalState = address.FederalState;
            _address.PostalCode = address.PostalCode;
            _address.Country = address.Country;
            _address.AddressType = address.AddressType;
        }

        public Address GetById(int id)
        {
            Address address = null!;
            foreach (var a in MyData.Addresses)
                if (a.Id == id)
                    return a;

            return null!;
        }

        public List<Address> GetByFederalState(string FederalState)
        {
            List<Address> address = new List<Address>();
            foreach(var a in MyData.Addresses)
            {
                if(a.FederalState.ToLower() == FederalState.ToLower())
                {
                    address.Add(a);
                }
            }

            return address;
        }

        public List<Address> GetByCountry(string Country)
        {
            List<Address> addresses = new List<Address>();
            foreach (var a in MyData.Addresses)
            {
                if (a.Country.ToLower() == Country.ToLower())
                {
                    addresses.Add(a);
                }
            }

            return addresses;
        }
    }
}
