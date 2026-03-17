using GildedRoseKata;
using Shouldly;
using Xunit;

namespace GildedRose.Tests
{
    public class SulfurasUpdaterTests
    {
        // Zero: Quality and SellIn are zero (should not change)
        [Fact]
        public void Update_SulfurasWithZeroQualityAndSellIn_DoesNotChange()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 0 };
            var updater = new SulfurasUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(0);
            item.SellIn.ShouldBe(0);
        }

        // One: Quality is one (should not change)
        [Fact]
        public void Update_SulfurasWithQualityOne_DoesNotChange()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 1 };
            var updater = new SulfurasUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(1);
            item.SellIn.ShouldBe(5);
        }

        // Many: Quality is greater than one (should not change)
        [Fact]
        public void Update_SulfurasWithQualityGreaterThanOne_DoesNotChange()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 };
            var updater = new SulfurasUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(80);
            item.SellIn.ShouldBe(5);
        }

        // Boundary: Quality at maximum (should not change)
        [Fact]
        public void Update_SulfurasWithQualityEighty_DoesNotChange()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 };
            var updater = new SulfurasUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(80);
        }

        // Interface: Update method exists and works
        [Fact]
        public void Update_MethodExistsAndDoesNothing()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 };
            var updater = new SulfurasUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(80);
            item.SellIn.ShouldBe(1);
        }

        // Exceptional: Quality cannot go above eighty (should not change)
        [Fact]
        public void Update_SulfurasWithQualityAboveEighty_DoesNotChange()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 100 };
            var updater = new SulfurasUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(100);
        }

        // Simple: Sulfuras does not change
        [Fact]
        public void Update_Sulfuras_DoesNotChange()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
            var updater = new SulfurasUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(80);
            item.SellIn.ShouldBe(10);
        }
    }
}


