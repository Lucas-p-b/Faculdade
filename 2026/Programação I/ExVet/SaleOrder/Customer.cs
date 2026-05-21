namespace SaleOrder
{
    public class Customer
    {
        public static int InstanceCount { get; set; }
        public int Id { get; set; }
        public string Name { get; set; } = null;
        public DateTime BirthDate { get; set; }

        public Customer()
        {
            InstanceCount++;
        }

        public override string ToString()
        {
            return $@" 
                Id {this.Id}, Name {this.Name}, Birth Date {this.BirthDate.ToLongDateString()}            
            ";
        }
    }
}
