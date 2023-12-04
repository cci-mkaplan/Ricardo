namespace Ricardo.Technical.Test.Data
{
	public class OrderItem
	{
		//public Inventory Inventory { get; private set; }
        public Stock Stock { get; }
        public Item Item { get; }
        public int Quantity { get; private set; }
		public int Total => Item.Price * Quantity;
		protected OrderItem(Stock stock, int quantity)//, Inventory inventory)
		{
			Item = stock.Item;
			Quantity = quantity;
           // Inventory = inventory;
        }

		public static OrderItem Create(Stock stock, int quantity)
		{
			var item = stock.Item;
			//var stockOfItem= Inventory.AllStock().Where(p=>p.Id==item.Id).FirstOrDefault();

            return new OrderItem(stock, quantity);
		}

		public void AddMore(int quantity)
		{
			if(quantity > 0)
				Quantity += quantity;
		}
	}
}
