namespace Ricardo.Technical.Test.Data
{
    public class Inventory
    {
        private readonly List<Item> _goods = new();

        public Inventory()
        {
            //Data seeding
            _goods.Add(new Item { Id = 1, Name = "Dice Set", Image = "images/Dice set.webp", Price = 50});
            _goods.Add(new Item { Id = 2, Name = "Dungeon Tiles", Image = "images/Dungeon tiles.jpg", Price = 100});
            _goods.Add(new Item { Id = 3, Name = "Dice Tower", Image = "images/Dice tower.jpg", Price = 200});
        }

        public IEnumerable<Item> AllStock()
        {
	        return _goods;
        }
    }
}
