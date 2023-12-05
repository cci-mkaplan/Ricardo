namespace Ricardo.Technical.Test.Utility
{
    public interface INavigation
    {
        bool CanNavigateBack { get; }

        void NavigateBack();
        void NavigateTo(string url);
    }
}