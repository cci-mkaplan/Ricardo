using Microsoft.AspNetCore.Components;
using Ricardo.Technical.Test.Data;
using Ricardo.Technical.Test.Utility;

namespace Ricardo.Technical.Test.Pages
{
	public partial class ViewBasket
	{
		[Inject] private Navigation NavManager { get; set; } = default!;
		[CascadingParameter] private Basket Basket { get; set; } = default!;
		public void Checkout()
		{
			NavManager.NavigateTo("/checkout");
		}
	}
}
