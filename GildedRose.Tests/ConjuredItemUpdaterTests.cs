using GildedRoseKata;
using Shouldly;
using Xunit;

namespace GildedRose.Tests
{
    public class ConjuredItemUpdaterTests
    {
        // Zero: Quality and SellIn are zero (should degrade quality by 2, but not below 0)
        [Fact]
        void Update_ConjuredWithZeroQualityAndSellIn_QualityStaysAtZero()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 0 };
            var updater = new ConjuredItemUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(0);
            item.SellIn.ShouldBe(-1);
        }

        // One: Quality is one, should degrade to 0
        [Fact]
        void Update_ConjuredWithQualityOne_QualityBecomesZero()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 1 };
            var updater = new ConjuredItemUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(0);
            item.SellIn.ShouldBe(4);
        }

        // Many: Quality is greater than two, should degrade by 2
        [Fact]
        void Update_ConjuredWithQualityGreaterThanTwo_QualityDecreasesByTwo()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 };
            var updater = new ConjuredItemUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(4);
            item.SellIn.ShouldBe(2);
        }

        // Boundary: Quality is 2, should go to 0
        [Fact]
        void Update_ConjuredWithQualityTwo_QualityBecomesZero()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 1, Quality = 2 };
            var updater = new ConjuredItemUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(0);
            item.SellIn.ShouldBe(0);
        }

        // Boundary: Quality is 0, should stay at 0
        [Fact]
        void Update_ConjuredWithQualityZero_QualityRemainsZero()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 2, Quality = 0 };
            var updater = new ConjuredItemUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(0);
            item.SellIn.ShouldBe(1);
        }

        // Interface: Can use as IItemUpdater
        [Fact]
        void Update_ConjuredItemUpdater_AsIItemUpdater_Works()
        {
            IItemUpdater updater = new ConjuredItemUpdater();
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 2, Quality = 4 };
            updater.Update(item);
            item.Quality.ShouldBe(2);
            item.SellIn.ShouldBe(1);
        }

        // Exceptional: Negative Quality clamps to 0
        [Fact]
        void Update_ConjuredWithNegativeQuality_QualityClampedToZero()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 2, Quality = -1 };
            var updater = new ConjuredItemUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(0);
            item.SellIn.ShouldBe(1);
        }

        // Simple: Typical scenario
        [Fact]
        void Update_ConjuredTypicalScenario_QualityDecreasesByTwo()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 10 };
            var updater = new ConjuredItemUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(8);
            item.SellIn.ShouldBe(4);
        }

        // Degrade twice as fast: Name starts with 'Conjured'
        [Fact]
        void Update_ConjuredItemWithDifferentName_QualityDegradesTwiceAsFast()
        {
            var item = new Item { Name = "Conjured Super Bread", SellIn = 3, Quality = 8 };
            var updater = new ConjuredItemUpdater();
            updater.Update(item);
            item.Quality.ShouldBe(6);
            item.SellIn.ShouldBe(2);
        }
    }
}

