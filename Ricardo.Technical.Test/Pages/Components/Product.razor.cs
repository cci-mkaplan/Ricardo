using Microsoft.AspNetCore.Components;
using Ricardo.Technical.Test.Data;

namespace Ricardo.Technical.Test.Pages.Components
{
    public partial class Product
    {
        private int _quantity = 1;
        [Parameter] public Stock Stock { get; set; } = default!;
        [Parameter] public EventCallback<OrderItem> OnItemAdded { get; set; }

        private void AddToBasket()
        {
            if (_quantity <= 0) return;
            if (Stock.Amount < _quantity) return;
            OnItemAdded.InvokeAsync(OrderItem.Create(Stock, _quantity));
        }
    }
}
