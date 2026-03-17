using GildedRoseKata;
using Shouldly;
using Xunit;

namespace GildedRose.Tests
{
    public class NormalItemUpdaterTests
    {
        // Zero: Quality and SellIn are zero
        [Fact]
        public void Update_ItemWithZeroQualityAndSellIn_DoesNotGoNegative()
        {
            var item = new Item { Name = "Normal Item", SellIn = 0, Quality = 0 };
            var updater = new NormalItemUpdater();
            updater.Update(item);
            item.Quality.ShouldBeGreaterThanOrEqualTo(0);
            item.SellIn.ShouldBe(-1);
        }

        // One: Quality is one
        [Fact]
        public void Update_ItemWithQualityOne_DecreasesQualityToZero()
        {
            var item = new Item { Name = "Normal Item", SellIn = 5, Quality = 1 };
            var updater = new NormalItemUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(0);
            item.SellIn.ShouldBe(4);
        }

        // Many: Quality is greater than one
        [Fact]
        public void Update_ItemWithQualityGreaterThanOne_DecreasesQualityByOne()
        {
            var item = new Item { Name = "Normal Item", SellIn = 5, Quality = 10 };
            var updater = new NormalItemUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(9);
            item.SellIn.ShouldBe(4);
        }

        // Boundary: SellIn below zero
        [Fact]
        public void Update_ItemWithSellInBelowZero_DecreasesQualityTwice()
        {
            var item = new Item { Name = "Normal Item", SellIn = 0, Quality = 10 };
            var updater = new NormalItemUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(8);
            item.SellIn.ShouldBe(-1);
        }

        // Interface: Update method exists and works
        [Fact]
        public void Update_MethodExistsAndUpdatesItem()
        {
            var item = new Item { Name = "Normal Item", SellIn = 1, Quality = 1 };
            var updater = new NormalItemUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(0);
            item.SellIn.ShouldBe(0);
        }

        // Exceptional: Quality cannot go below zero
        [Fact]
        public void Update_ItemWithZeroQuality_DoesNotGoNegative()
        {
            var item = new Item { Name = "Normal Item", SellIn = 5, Quality = 0 };
            var updater = new NormalItemUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(0);
        }

        // Simple: Normal decrement
        [Fact]
        public void Update_NormalItem_DecrementsSellInAndQuality()
        {
            var item = new Item { Name = "Normal Item", SellIn = 10, Quality = 20 };
            var updater = new NormalItemUpdater();
            updater.Update(item);
            item.SellIn.ShouldBe(9);
            item.Quality.ShouldBe(19);
        }
    }
}


