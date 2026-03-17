using GildedRoseKata;
using Shouldly;
using Xunit;

namespace GildedRose.Tests
{
    public class BackstagePassesUpdaterTests
    {
        // Zero: Quality and SellIn are zero
        [Fact]
        public void Update_BackstagePassesWithZeroQualityAndSellIn_QualityDropsToZero()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 0 };
            var updater = new BackstagePassesUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(0);
            item.SellIn.ShouldBe(-1);
        }

        // One: Quality is one
        [Fact]
        public void Update_BackstagePassesWithQualityOne_IncreasesQuality()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 1 };
            var updater = new BackstagePassesUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(2);
            item.SellIn.ShouldBe(14);
        }

        // Many: Quality increases by more near concert
        [Fact]
        public void Update_BackstagePassesWithSellInLessThanTen_IncreasesQualityByTwo()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 };
            var updater = new BackstagePassesUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(12);
            item.SellIn.ShouldBe(9);
        }

        [Fact]
        public void Update_BackstagePassesWithSellInLessThanFive_IncreasesQualityByThree()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 };
            var updater = new BackstagePassesUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(13);
            item.SellIn.ShouldBe(4);
        }

        // Boundary: Quality at maximum
        [Fact]
        public void Update_BackstagePassesWithQualityFifty_DoesNotExceedFifty()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 50 };
            var updater = new BackstagePassesUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(50);
        }

        // Interface: Update method exists and works
        [Fact]
        public void Update_MethodExistsAndUpdatesBackstagePasses()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 1 };
            var updater = new BackstagePassesUpdater();
            updater.Update(item);
            item.Quality.ShouldBeGreaterThanOrEqualTo(1);
            item.SellIn.ShouldBe(0);
        }

        // Exceptional: Quality drops to zero after concert
        [Fact]
        public void Update_BackstagePassesAfterConcert_QualityDropsToZero()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 };
            var updater = new BackstagePassesUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(0);
        }

        // Simple: Normal increment
        [Fact]
        public void Update_BackstagePasses_NormalIncrement()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };
            var updater = new BackstagePassesUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(21);
            item.SellIn.ShouldBe(14);
        }
    }
}


