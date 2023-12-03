using Microsoft.AspNetCore.Mvc;
using Ricardo.Technical.Test.Data;

namespace Ricardo.Technical.Test
{
	[ApiController]
	public class InventoryController : Controller
	{
		private readonly Inventory _inventory;
		public InventoryController(Inventory inventory)
		{
			_inventory = inventory;
		}
		[HttpGet("GetItems")]
		public IActionResult Get()
		{
			return Ok(_inventory.AllStock());
		}
	}
}
