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

		[Inject] private Inventory Inventory { get; set; }= default!;

		protected override async Task OnInitializedAsync()
		{
			_stock = Inventory.AllStock();
			await base.OnInitializedAsync();
		}

		public void ItemAdded(Item item)
		{
			_messages.Add(new ToastMessage(ToastType.Success, $"{item.Name} added to basket." ));
		}

	}
}
