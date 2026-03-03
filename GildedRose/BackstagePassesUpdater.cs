namespace GildedRoseKata
{
    public class BackstagePassesUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            // Step 1: Age the item
            item.SellIn--;

            // Step 2: Quality adjustment before expiration
            if (item.SellIn >= 0)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                    if (item.SellIn < 10 && item.Quality < 50)
                        item.Quality++;
                    if (item.SellIn < 5 && item.Quality < 50)
                        item.Quality++;
                }
            }
            // Step 3: Quality drops to 0 after expiration
            else
            {
                item.Quality = 0;
            }
        }
    }
}
