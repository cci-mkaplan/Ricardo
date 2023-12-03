using Microsoft.AspNetCore.Components;
using Ricardo.Technical.Test.Data;
using Ricardo.Technical.Test.Utility;

namespace Ricardo.Technical.Test.Pages
{
	public partial class SignIn
	{
		[Inject] private CustomerService CustomerService { get; set; } = default!;
		[Inject] private Navigation NavManager { get; set; } = default!;
		private string _username = default!;
		private string _password = default!;

		private void Submit()
		{
			var signInResult = CustomerService.SignIn(_username, _password);
		
				BackToPreviousPage();
		}

		private void BackToPreviousPage()
		{
			if(NavManager.CanNavigateBack)
				NavManager.NavigateBack();
			else
				NavManager.NavigateTo("/browse");
		}
	}
}
