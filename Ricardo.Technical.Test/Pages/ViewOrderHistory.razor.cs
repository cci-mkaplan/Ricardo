using Microsoft.AspNetCore.Components;
using Ricardo.Technical.Test.Data;
using Ricardo.Technical.Test.Utility;

namespace Ricardo.Technical.Test.Pages
{
	public partial class ViewOrderHistory
	{
		[Inject] private Navigation NavManager { get; set; } = default!;

		[Inject] private  SessionManager? SessionManager { get; set; }= default!;

		public Customer Customer => SessionManager.Customer;
    }
}
