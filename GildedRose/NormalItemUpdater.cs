namespace GildedRoseKata
{
    public class NormalItemUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            // Step 1: Age the item
            item.SellIn--;

            // Step 2: Regular Quality decrement
            if (item.Quality > 0)
            {
                item.Quality--;
            }

            // Step 3: Additional decrement if expired
            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }
}
