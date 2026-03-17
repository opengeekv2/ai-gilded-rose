namespace GildedRoseKata
{
    public class AgedBrieUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            // Step 1: Age the item
            item.SellIn--;

            // Step 2: Quality adjustment
            if (item.Quality < 50)
            {
                item.Quality++;
            }

            // Step 3: Additional Quality increment if expired
            if (item.SellIn < 0 && item.Quality < 50)
            {
                item.Quality++;
            }
        }
    }
}
