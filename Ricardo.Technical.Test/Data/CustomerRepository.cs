namespace Ricardo.Technical.Test.Data
{
    public class CustomerRepository
    {
        private readonly List<Customer> _customers = new();

        public CustomerRepository()
        {
            //Data seeding
            _customers.Add(new Customer(BankAccount.Open(200), "test", "1234", "Jeremy Irons"));
        }

        public Customer? FindCustomerByUsernameAndPassword(string username, string password)
        {
            var customer = _customers.Where(p => p.Username == username && p.Password == password).FirstOrDefault();
            return customer;
        }
    }
}
