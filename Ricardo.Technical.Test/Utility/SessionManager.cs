using Ricardo.Technical.Test.Data;

namespace Ricardo.Technical.Test.Utility
{
    public class SessionManager : ISessionManager
    {
        public Customer? Customer { get; private set; }

        public event Action? OnSignIn;
        public void SignedIn(Customer customer)
        {
            Customer = customer;
            NotifyStateChanged();
        }

        public void SignOut()
        {
            Customer = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnSignIn?.Invoke();
    }
}
