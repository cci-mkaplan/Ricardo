using Microsoft.AspNetCore.Components;
using Ricardo.Technical.Test.Data;

namespace Ricardo.Technical.Test.Shared
{
    public partial class Shop
    {
	    private Basket Basket { get; set; } = default!;
        [Parameter] public RenderFragment? ChildContent { get; set; }

        protected override void OnInitialized()
        {
	        Basket = new Basket();
	        base.OnInitialized();
        }
    }
}
