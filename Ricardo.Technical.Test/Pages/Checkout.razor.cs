using Microsoft.AspNetCore.Components;
using Ricardo.Technical.Test.Data;
using Ricardo.Technical.Test.Utility;

namespace Ricardo.Technical.Test.Pages
{
	public partial class Checkout
	{
		[Inject] private Navigation NavManager { get; set; } = default!;
		[Inject] private SessionManager SessionManager { get; set; } = default!;
		[CascadingParameter] private Basket Basket { get; set; } = default!;

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
           
            var stocks = Order.GetStockByBasket(Basket);
			foreach (var stock in stocks)
			{
				Inventory.RemoveFromStock(stock);
			}
            customer.Pay(order);

			Basket.EmptyBasket();
            customer.AddToOrderHistory(order);
            //should be transactional

            NavManager.NavigateTo("/orderConfirmed");
		
		}

	}
}
