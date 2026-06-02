using Model;
using Repository.VirtualDataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class AddressRepository : BaseRepository<Address>
    {
        public Address Create(Address address)
        {
            address.Id = GetNextId();
            MyData.Addresses.Add(address);
            return address;
        }
        public void Delete(Address address)
        {
            MyData.Addresses.Remove(address);
        }
        public void Update(Address address)
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
            foreach (var a in MyData.Addresses)
                if (a.Id == id)
                    return a;
            return null!;
        }
        public List<Address> GetByFederalState(string federalState)
        {
            List<Address> addresses = new List<Address>();

            foreach (var a in MyData.Addresses)
            {
                if (a.FederalState.ToLower() == federalState.ToLower())
                {
                    addresses.Add(a);
                }
            }
            return addresses;
        }
        public List<Address> GetByCountry(string country)
        {
            List<Address> addresses = new List<Address>();

            foreach (var a in MyData.Addresses)
            {
                if (a.Country.ToLower() == country.ToLower())
                {
                    addresses.Add(a);
                }
            }
            return addresses;
        }
    }
}