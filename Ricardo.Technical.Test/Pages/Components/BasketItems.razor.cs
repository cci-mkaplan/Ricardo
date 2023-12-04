using Microsoft.AspNetCore.Components;
using Ricardo.Technical.Test.Data;
using Ricardo.Technical.Test.Utility;

namespace Ricardo.Technical.Test.Pages.Components
{
	public partial class BasketItems
	{
		[CascadingParameter] private Basket Basket { get; set; } = default!;

		[Parameter] public OrderItem OrderItem { get; set; } = default!;

		[Inject] private Navigation NavManager { get; set; } = default!;

		public void RemoveFromBasket(OrderItem OrderItem)
		{
			Basket.RemoveFromBasket(OrderItem);
			if(Basket.Items.Count<1)
				NavManager.NavigateTo("/basket");
		}
	}
}
