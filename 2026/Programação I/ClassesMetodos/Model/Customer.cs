namespace Model
{
    public class Customer : People
    {
        #region Properties
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public Customer() { }
        #endregion

        #region Constructors
        public Customer
        (
            int id,
            string firstName,
            string lastName,
            string email,
            string phone
        )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        #endregion
        #region Validations
        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(FirstName)) return false;
            if (string.IsNullOrWhiteSpace(LastName)) return false;
            if (string.IsNullOrWhiteSpace(Email)) return false;

            return true;
        }
        #endregion
    }
}
