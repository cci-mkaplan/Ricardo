using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Ricardo.Technical.Test.Data;
using Ricardo.Technical.Test.Errors;
using Ricardo.Technical.Test.Utility;

namespace Ricardo.Technical.Test.Pages
{
	public partial class Checkout
	{
		[Inject] private INavigation NavManager { get; set; } = default!;
		[Inject] private SessionManager SessionManager { get; set; } = default!;
		[CascadingParameter] private Basket Basket { get; set; } = default!;

        private object thisLock = new();

        private readonly List<ToastMessage> _messages = new();

        [Inject] private Inventory Inventory { get; set; } = default!;

        public void PlaceOrder()
		{
			var customer = SessionManager.Customer;
			if (customer == default!)
			{
				NavManager.NavigateTo("/signin");
				return;
			}

			//should be transactional cos stock moving can give an error anytime and we need to revert the payment. But that is unnecssary for now. 
			var order = Order.Create(Basket);
          
			try
            {
                customer.Pay(order);
                var stocks = Order.GetStockByBasket(Basket);

                lock (thisLock) // we have to lock the stock removing process cos too much  process will be reaching this and they have to see the same sycnronized stock.
                {
                    RemoveFromStock(stocks);
                }
                Basket.EmptyBasket();
                customer.AddToOrderHistory(order);
            }
            catch (InsufficientFundsException ex)
			{
                _messages.Add(new ToastMessage(ToastType.Danger, ex.Message));
				return;
			}
            //end of transaction transactional

            NavManager.NavigateTo("/orderConfirmed");
		
		}

        private void RemoveFromStock(List<Stock> stocks)
        {
            foreach (var stock in stocks)
            {
                Inventory.RemoveFromStock(stock);
            }
        }
    }
}
