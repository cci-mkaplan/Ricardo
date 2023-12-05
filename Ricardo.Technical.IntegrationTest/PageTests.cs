using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Ricardo.Technical.Test.Data;
using Ricardo.Technical.Test.Pages;
using Ricardo.Technical.Test.Pages.Components;
using Ricardo.Technical.Test.Utility;

namespace Ricardo.Technical.IntegrationTest;

public class PageTests : TestContext
{
    private Inventory? Inventory { get; set; }
    private Basket? Basket { get; set; }

    public PageTests()
    {
        InitialCommonConfig();
    }

    [Fact]
    public void Can_Add_Items_To_Baset()
    {
        // Arrange
        Inventory = new Inventory();
        Basket = new Basket();
        Action addToBasketHandler = () => { };

        var cut = RenderComponent<Products>(parameters => parameters
                          .Add(p => p.OnItemAdded, addToBasketHandler)
                          .Add(p => p.Goods, Inventory.AllStock())
                          .Add(p => p.Basket, Basket) //the reason that I make basket property from protected to public is to test it
                        );

        var paraElm = cut.Find("button");

        // Act
        cut.Find("button").Click();

        //// Assert
        Assert.True(paraElm != null);
        Assert.True(Basket.Items.Any());
    }

    [Fact]
    public void Can_Remove_Things_From_Basket()
    {
        var someItemPrice = 100;
        OrderItem orderItem = AddSometingToBasket(someItemPrice);

        var cut = RenderComponent<BasketItems>(parameters => parameters
                  .Add(p => p.OrderItem, orderItem)
                  .Add(p => p.Basket, Basket)
                );

        var paraElm = cut.Find("button");

        // Act
        cut.Find("button").Click();

        Assert.True(paraElm != null);
        Assert.True(!Basket.Items.Any());
    }

    [Fact]
    public void Can_Items_In_Basket_Be_Purchased_With_Sufficient_Funds()
    {
        var someItemPrice = 100;
        var orderItem = AddSometingToBasket(someItemPrice);

        var cut = RenderComponent<Checkout>(parameters => parameters
          .Add(p => p.Basket, Basket)
        );

        var paraElm = cut.Find("button.Order"); //refers to 'order now' button

        // Act
        cut.Find("button.Order").Click();

        Assert.True(paraElm != null);
        Assert.True(!Basket.Items.Any()); // operation must clear the basket
    }

    [Fact]
    public void Can_Items_In_Basket_Not_Be_Purchased_With_InSufficient_Funds()
    {
        var someItemWithHigherPrice = 500;
        var orderItem = AddSometingToBasket(someItemWithHigherPrice);

        var cut = RenderComponent<Checkout>(parameters => parameters
          .Add(p => p.Basket, Basket)
        );

        // I used InvalidOperationException to catch outer exception here.
        // That is becouse main PlaceOrder function gives InsufficientFundsException when there is not enough funds on the account and I catch it in the main function to give customer a proper message.

        Assert.Throws<InvalidOperationException>(() => cut.Find("button.Order").Click()); 
    }

    private void InitialCommonConfig()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var mockwebHostEnvironment = Substitute.For<IWebHostEnvironment>();

        Services.AddSingleton<IConfiguration>(configuration);
        Services.AddSingleton<IWebHostEnvironment>(provider => mockwebHostEnvironment);
        Services.AddRazorPages();
        Services.AddServerSideBlazor();
        Services.AddBlazorBootstrap();
        Services.AddSingleton<Inventory>();
        Services.AddScoped<INavigation, MockNavigation>();
        Services.AddScoped<CustomerRepository>();
        Services.AddScoped<CustomerService>();
        Services.AddScoped<ISessionManager, MockSessionManager>();
        Services.AddScoped<Basket>();
    }

    private OrderItem AddSometingToBasket(int price)
    {
        Basket = new Basket();

        var stock = new Stock()
        {
            Amount = 1,
            Item = new Item
            {
                Id = 1,
                Image = string.Empty,
                Name = "TestProducts",
                Price = price,
                UnitType = UnitType.Piece
            }
        };

        var orderItem = new OrderItem(stock, 1);

        Basket.AddToBasket(orderItem);
        return orderItem;
    }

    public class MockNavigation : INavigation
    {
        public bool CanNavigateBack => true;

        public void NavigateBack()
        {

        }

        public void NavigateTo(string url)
        {

        }
    }

    public class MockSessionManager : ISessionManager
    {
        public Customer? Customer => new Customer(BankAccount.Open(200), "test", "1234", "Jeremy Irons");

        public event Action? OnSignIn;

        public void SignedIn(Customer customer)
        {
            // throw new NotImplementedException();
        }

        public void SignOut()
        {
            //throw new NotImplementedException();
        }
    }
}
