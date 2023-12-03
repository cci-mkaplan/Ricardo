using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Ricardo.Technical.Test.Data;

namespace Ricardo.Technical.Test.Pages
{
	public partial class Browse
	{
		private readonly List<ToastMessage> _messages = new();
		private IEnumerable<Stock> _stock = new List<Stock>();
		[Inject] private HttpClient HttpClient { get; set; } = default!;

		protected override async Task OnInitializedAsync()
		{
			var response = await HttpClient.GetAsync("GetItems");
			var data = await response.Content.ReadAsStringAsync();
			_stock = JsonConvert.DeserializeObject<List<Stock>>(data)!;
			await base.OnInitializedAsync();
		}

		public void ItemAdded(Item item)
		{
			_messages.Add(new ToastMessage(ToastType.Success, $"{item.Name} added to basket." ));
		}

	}
}
