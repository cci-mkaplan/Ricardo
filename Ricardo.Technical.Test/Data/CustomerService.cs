using Ricardo.Technical.Test.Utility;

namespace Ricardo.Technical.Test.Data
{
	public class CustomerService
	{
		private readonly CustomerRepository _repository;
		private readonly ISessionManager _sessionManager;

		public CustomerService(CustomerRepository repository, ISessionManager sessionManager)
		{
			_repository = repository;
			_sessionManager = sessionManager;
		}

		public Customer? SignIn(string username, string password)
		{
			var customer = _repository.FindCustomerByUsernameAndPassword(username, password);
			if (customer != default!)
			{
				_sessionManager.SignedIn(customer);
			}
			return customer;
		}
	}
}
