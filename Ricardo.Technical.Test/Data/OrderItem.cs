namespace Ricardo.Technical.Test.Data
{
	public class OrderItem
	{
		public Item Item { get; }
		public int Quantity { get; private set; }
		public int Total => Item.Price * Quantity;
		protected OrderItem(Item item, int quantity)
		{
			Item = item;
			Quantity = quantity;
		}

		public static OrderItem Create(Item item, int quantity)
		{
			return new OrderItem(item, quantity);
		}

		public void AddMore(int quantity)
		{
			if(quantity > 0)
				Quantity += quantity;
		}
	}
}
