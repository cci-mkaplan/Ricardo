using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Ricardo.Technical.Test.Data;

namespace Ricardo.Technical.Test.Pages.Components
{
    public partial class Product
    {
        private int _quantity = 1;
        [Parameter] public Stock Stock { get; set; } = default!;
        [Parameter] public EventCallback<OrderItem> OnItemAdded { get; set; }

        [Inject] private Inventory Inventory { get; set; } = default!;

        [Inject] private Basket Basket { get; set; } = default!;

        private readonly List<ToastMessage> _messages = new();

        public void AddToBasket()
        {
            if (_quantity <= 0) return;

            if (Stock.Amount < _quantity)
            {
                _messages.Add(new ToastMessage(ToastType.Danger, $"Item in the basket can not be less than stock amount"));
                return;
            }

            var itemExistOnCurentBasket = Basket.Items.FirstOrDefault(p => p.Item.Id == Stock.Item.Id);

            if (itemExistOnCurentBasket != null)
            {
                var existingStock = Stock;
                var itemInTheBasket = itemExistOnCurentBasket.Quantity;
                var stock = Inventory.AllStock().Where(i => i.Item.Id == Stock.Item.Id).FirstOrDefault();

                if (stock != null)
                {
                    var stockQuantity = stock.Amount;
                    if (_quantity + itemInTheBasket > stockQuantity)
                    {
                        _messages.Add(new ToastMessage(ToastType.Danger, $"The amount of the item ({itemInTheBasket}) still in the basket and the amount of item u wanted to add ({_quantity}) into basket can not be more than the stock ({stockQuantity})!"));
                        return;
                    }
                }
            }

            OnItemAdded.InvokeAsync(OrderItem.Create(Stock, _quantity));
        }
    }
}
