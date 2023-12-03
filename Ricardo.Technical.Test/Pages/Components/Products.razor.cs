using Microsoft.AspNetCore.Components;
using Ricardo.Technical.Test.Data;

namespace Ricardo.Technical.Test.Pages.Components
{
    public partial class Products
    {
        [Parameter] public IEnumerable<Stock> Goods { get; set; } = default!;
        [CascadingParameter] protected Basket Basket { get; set; } = default!;
        [Parameter] public EventCallback<Item> OnItemAdded { get; set; } = default!;

        public void AddToBasket(OrderItem orderItem)
        {
	        Basket.AddToBasket(orderItem);
	        OnItemAdded.InvokeAsync(orderItem.Item);
        }
    }
}
