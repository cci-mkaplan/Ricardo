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

			//should be transactional
			var order = Order.Create(Basket);
          
			try
			{
                customer.Pay(order);
                var stocks = Order.GetStockByBasket(Basket);
                foreach (var stock in stocks)
                {
                    Inventory.RemoveFromStock(stock);
                }

                Basket.EmptyBasket();
                customer.AddToOrderHistory(order);
            }
			catch (InsufficientFundsException ex)
			{
                _messages.Add(new ToastMessage(ToastType.Danger, ex.Message));
				return;
			}
            //should be transactional

            NavManager.NavigateTo("/orderConfirmed");
		
		}

	}
}
