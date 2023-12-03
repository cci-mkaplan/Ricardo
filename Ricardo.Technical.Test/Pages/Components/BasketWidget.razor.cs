using Microsoft.AspNetCore.Components;
using Ricardo.Technical.Test.Utility;

namespace Ricardo.Technical.Test.Pages.Components
{
	public partial class BasketWidget
	{
		[Inject] private Navigation NavManager { get; set; } = default!;
		public void ViewBasket()
		{
			NavManager.NavigateTo("/basket");
		}
	}
}
