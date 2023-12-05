using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Ricardo.Technical.Test.Data;
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
        Services.AddScoped<Navigation>();
        Services.AddScoped<CustomerRepository>();
        Services.AddScoped<CustomerService>();
        Services.AddScoped<SessionManager>();
        Services.AddScoped<Basket>();
    }
}
