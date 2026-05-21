using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Model
{
    public class GovernmentCustomer : Customer
    {
        public String FiscalCode { get; set; } = string.Empty;

        public GovernmentCustomer()
        { 
        }
    }
}
