
namespace Ricardo.Technical.Test.Data
{
    public class Basket
    {
        private List<OrderItem> _items = new();
        public IReadOnlyList<OrderItem> Items => _items;

        public void AddToBasket(OrderItem orderItem)
        {
            var existing = _items.SingleOrDefault(i => i.Item.Id == orderItem.Item.Id);
            if (existing == default)
                _items.Add(orderItem);
            else
                existing.AddMore(orderItem.Quantity);
        }
        public void EmptyBasket()
        {
            _items.Clear();
        }
    }
}

