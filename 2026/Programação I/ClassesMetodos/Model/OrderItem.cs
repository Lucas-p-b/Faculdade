using System.Xml.Linq;

namespace Model
{
    public class OrderItem
    {
        #region Atributes
        public int Id { get; set; }
        public Product Product { get; set; } = null!;
        public float Qty { get; set; }
        public double SalePrice { get; set; }
        public double TotalPrice { get; set; }
        #endregion

        #region Constructors
        public OrderItem(
            int id, 
            Product product, 
            float qty, 
            double salePrice, 
            double totalPrice)
        {
            Id = id;
            Product = product;
            Qty = qty;
            SalePrice = salePrice;
            TotalPrice = totalPrice;
        }
        #endregion
        #region Validations
        public bool Validate()
        {
            if (Qty <= 0) return false;
            if (SalePrice <= 0) return false;
            if (TotalPrice <= 0) return false;

            return true;
        }
        #endregion
    }
}
