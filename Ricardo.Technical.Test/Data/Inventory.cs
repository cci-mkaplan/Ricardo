namespace Ricardo.Technical.Test.Data
{
    public class Inventory
    {
        private readonly List<Stock> _goods = new();

        public Inventory()
        {
            //Data seeding
            _goods.Add(new Stock { Item = new Item { Id = 1, Name = "Dice Set", Image = "images/Dice set.webp", Price = 50, UnitType = UnitType.Piece }, Amount = 5 });
            _goods.Add(new Stock { Item = new Item { Id = 2, Name = "Dungeon Tiles", Image = "images/Dungeon tiles.jpg", Price = 100, UnitType = UnitType.Piece }, Amount = 10 });
            _goods.Add(new Stock { Item = new Item { Id = 3, Name = "Dice Tower", Image = "images/Dice tower.jpg", Price = 200, UnitType = UnitType.Piece }, Amount = 5 });
        }

        public IEnumerable<Stock> AllStock()
        {
            return _goods;
        }
    }

    public class Stock
    {
        public Item? Item { get; set; }
        public int Amount { get; set; }
    }
}
