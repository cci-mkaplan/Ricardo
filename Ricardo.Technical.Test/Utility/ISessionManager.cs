using Ricardo.Technical.Test.Data;

namespace Ricardo.Technical.Test.Utility
{
    public interface ISessionManager
    {
        Customer? Customer { get; }

        event Action? OnSignIn;

        void SignedIn(Customer customer);
        void SignOut();
    }
}