using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Model
{
    #region Atributes
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public Product () { }
    #endregion
        #region Constructors
        public Product(
            int id, 
            string name, 
            decimal price
        )
        {
            Id = id;
            Name = name;
            Price = price;
        }
        #endregion
        #region Validations
        /// <summary>
        /// Valida se o nome e o valor é menor ou igual a 0
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            if(string.IsNullOrEmpty(Name)) return false;
            if (Price <= 0) return false;

            return true;
        }
        #endregion
    }
}
