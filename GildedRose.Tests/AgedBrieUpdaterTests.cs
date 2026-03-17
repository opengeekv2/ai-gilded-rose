using GildedRoseKata;
using Shouldly;
using Xunit;

namespace GildedRose.Tests
{
    public class AgedBrieUpdaterTests
    {
        // Zero: Quality and SellIn are zero
        [Fact]
        public void Update_AgedBrieWithZeroQualityAndSellIn_IncreasesQuality()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 };
            var updater = new AgedBrieUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(2);
            item.SellIn.ShouldBe(-1);
        }

        // One: Quality is one
        [Fact]
        public void Update_AgedBrieWithQualityOne_IncreasesQuality()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 1 };
            var updater = new AgedBrieUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(2);
            item.SellIn.ShouldBe(4);
        }

        // Many: Quality is greater than one
        [Fact]
        public void Update_AgedBrieWithQualityGreaterThanOne_IncreasesQuality()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 };
            var updater = new AgedBrieUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(11);
            item.SellIn.ShouldBe(4);
        }

        // Boundary: Quality at maximum
        [Fact]
        public void Update_AgedBrieWithQualityFifty_DoesNotExceedFifty()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 };
            var updater = new AgedBrieUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(50);
        }

        // Interface: Update method exists and works
        [Fact]
        public void Update_MethodExistsAndUpdatesAgedBrie()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 };
            var updater = new AgedBrieUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(2);
            item.SellIn.ShouldBe(0);
        }

        // Exceptional: Quality cannot go above fifty
        [Fact]
        public void Update_AgedBrieWithQualityNearFifty_DoesNotExceedFifty()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 49 };
            var updater = new AgedBrieUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(50);
        }

        // Simple: Normal increment
        [Fact]
        public void Update_AgedBrie_NormalIncrement()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 };
            var updater = new AgedBrieUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(21);
            item.SellIn.ShouldBe(9);
        }
    }
}


