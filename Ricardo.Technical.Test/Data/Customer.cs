namespace Ricardo.Technical.Test.Data
{
    public class Customer
    {
        public string Name { get; }
        public string Username { get; }
        public BankAccount Account { get; }

        public  List<Order> OrderHistory { get; private set; } = new();

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

        public void AddToOrderHistory(Order order)
        {
            OrderHistory.Add(order);
        }
    }
}
