namespace Ricardo.Technical.Test.Data
{
    public class Order
    {
	    private readonly List<OrderItem> _items = new();
        public int Total { get; }
        public Order(OrderItem[] items)
        {
            Total = items.Sum(p => p.Total);
            _items.AddRange(items);
        }
        public static Order Create(Basket basket)
        {
            return new Order(basket.Items.ToArray());
        }

        public static List<Stock> GetStockByBasket(Basket basket)
        {
            var stocks= basket.Items.Select(p=> new Stock { Amount= p.Quantity, Item= p.Item}).ToList();
            return stocks;
        }
    }
}
