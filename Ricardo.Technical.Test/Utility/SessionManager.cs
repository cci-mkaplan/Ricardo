using Ricardo.Technical.Test.Data;

namespace Ricardo.Technical.Test.Utility
{
	public class SessionManager
	{
		public Customer? Customer { get; private set; }

		public event Action? OnSignIn;
		public void SignedIn(Customer customer)
		{
			Customer = customer;
			NotifyStateChanged();
		}

		private void NotifyStateChanged() => OnSignIn?.Invoke();
	}
}
