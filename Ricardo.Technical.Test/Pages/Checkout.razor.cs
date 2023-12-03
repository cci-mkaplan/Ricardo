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

		public void PlaceOrder()
		{
			var customer = SessionManager.Customer;
			if (customer == default!)
			{
				NavManager.NavigateTo("/signin");
				return;
			}

			var order = Order.Create(Basket);

			customer.Pay(order);
			NavManager.NavigateTo("/orderConfirmed");
		
		}

	}
}
