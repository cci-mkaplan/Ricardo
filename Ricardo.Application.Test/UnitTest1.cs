using Ricardo.Technical.Test.Data;

namespace Ricardo.Application.Test
{
    public class Tests
    {
        private  Inventory Inventory { get; set; }

        private Basket Basket { get; set; }

        [SetUp]
        public void Setup()
        {
            Inventory= new Inventory();
            Basket= new Basket();
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
            Basket.AddToBasket()
        }
    }
}