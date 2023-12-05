using Microsoft.VisualStudio.TestPlatform.TestHost;
using Ricardo.Technical.Test.Data;
using Ricardo.Technical.Test.Pages.Components;

namespace Ricardo.Application.Test
{
    public class Tests
    {
        private  Inventory Inventory { get; set; }

        private Products Products { get; set; }
            
        private Technical.Test.Pages.Components.Product Product { get; set; }

        private Basket Basket { get; set; }

        [SetUp]
        public void Setup()
        {
            Inventory= new Inventory();
            Basket= new Basket();
            Products= new Products();
            Products.Goods = Inventory.AllStock();
            Product = new Technical.Test.Pages.Components.Product();
        }

        [Test]
        public void Can_List_Inventory()
        {
            var allStocks = Inventory.AllStock();
            Assert.IsTrue(allStocks.Any());
        }


        [Test]
        public void Can_Add_Items_To_Baset()
        {
           var stocks= Products.Goods.ToList();

            foreach (var stock in stocks)
            {
                
            }
        }
    }
}