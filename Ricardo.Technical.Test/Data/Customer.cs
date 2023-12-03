namespace Ricardo.Technical.Test.Data
{
    public class Customer
    {
	    public string Name { get; }
        public string Username { get; }
        public BankAccount Account { get; }

        public string Password { get; }
	    public Customer(BankAccount account, string username, string password, string name)
	    {
            Username = username;
            Password = password;
            Account = account;
		    Name = name;
	    }

	    public void Pay(Order order)
        {
	        Account.Withdraw(order.Total);
        }
    }
}
