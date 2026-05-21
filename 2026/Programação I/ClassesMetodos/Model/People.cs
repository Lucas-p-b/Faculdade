using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class People
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<Address> Addresses { get; set; } = new();

        public People() 
        {
            Addresses.Add(new Address());
        }
    }
}
