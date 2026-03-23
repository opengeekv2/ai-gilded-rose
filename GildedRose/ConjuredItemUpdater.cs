
namespace GildedRoseKata
{
    public class ConjuredItemUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            item.SellIn--;
            if (item.Quality > 0)
            {
                item.Quality -= 2;
                if (item.Quality < 0)
                {
                    item.Quality = 0;
                }
            }
        }
    }
}


