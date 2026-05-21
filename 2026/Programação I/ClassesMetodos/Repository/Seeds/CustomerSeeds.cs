using Model;
using Repository.VirtualDataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Seeds
{
    public static class CustomerSeeds
    {
        public static void Seed()
        { 

            if (MyData.Customers.Count < 1);
            {

            Customer c1 = new Customer();
            c1.Id = 1;
            c1.FirstName = "Jão";
            c1.LastName = "Oliveira";
            c1.Email = "jao.oliveira@bol";
            c1.Phone = "123456789";
            
            Address c1Address = new Address();
            c1Address.Id = 1;
            c1Address.FederalState = "SC";
            c1Address.Street = "Rua dos Cachorros";
            c1Address.Number = "123";
            c1Address.Country = "Brasil";
            c1Address.City = "Pinheiro Preto";
            c1Address.PostalCode = "89570000";
            c1Address.AddressType = AddressType.Residential;

                Customer c2 = new Customer();
            c2.Id = 1;
            c2.FirstName = "Jão2";
            c2.LastName = "Silva";
            c2.Email = "jao.silva@bol";
            c2.Phone = "123456789";

            Address c2Address = new Address();
            c2Address.Id = 1;
            c2Address.FederalState = "SC";
            c2Address.Street = "Rua dos Cachorros";
            c2Address.Number = "123";
            c2Address.Country = "Brasil";
            c2Address.City = "Tnagará";
            c2Address.PostalCode = "89570000";
            c2Address.AddressType = AddressType.Residential;

            Customer c3 = new Customer();
            c3.Id = 1;
            c3.FirstName = "Jão3";
            c3.LastName = "Costa";
            c3.Email = "jao.costa@bol";
            c3.Phone = "123456789";

            Address c3Address = new Address();
            c3Address.Id = 1;
            c3Address.FederalState = "SC";
            c3Address.Street = "Rua dos Cachorros";
            c3Address.Number = "123";
            c3Address.Country = "Brasil";
            c3Address.City = "Videira";
            c3Address.PostalCode = "89570000";
            c3Address.AddressType = AddressType.Residential;

            c1.Addresses.Add(c1Address);

                MyData.Customers.Add(c1);

            }

        }
    }
}
