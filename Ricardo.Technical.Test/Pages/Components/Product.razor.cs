using Microsoft.AspNetCore.Components;
using Ricardo.Technical.Test.Data;

namespace Ricardo.Technical.Test.Pages.Components
{
	public partial class Product
	{
		private int _quantity = 1;
		[Parameter] public Item Item { get; set; } = default!;
		[Parameter] public EventCallback<OrderItem> OnItemAdded { get; set; }

		private void AddToBasket()
		{
			if (_quantity <= 0) return;
			OnItemAdded.InvokeAsync(OrderItem.Create(Item, _quantity));
		}
	}
}
