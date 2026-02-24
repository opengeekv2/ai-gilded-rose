namespace GildedRoseKata
{
    public class NormalItemUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            if (item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros")
                item.Quality--;
            if (item.Name != "Sulfuras, Hand of Ragnaros")
                item.SellIn--;
            if (item.SellIn < 0 && item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros")
                item.Quality--;
        }
    }
}
