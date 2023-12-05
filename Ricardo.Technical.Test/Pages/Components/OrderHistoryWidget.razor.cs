using Microsoft.AspNetCore.Components;
using Ricardo.Technical.Test.Data;
using Ricardo.Technical.Test.Utility;
using System.Runtime.CompilerServices;

namespace Ricardo.Technical.Test.Pages.Components
{
	public partial class OrderHistoryWidget
	{
		[Inject] private Navigation NavManager { get; set; } = default!;
		public void ViewOrderHistory()
		{
			NavManager.NavigateTo("/orderHistory");
		}
	}
}
