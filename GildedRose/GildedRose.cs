using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    private const string AgedBrie = "Aged Brie";
    private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
    private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    private void DegradeQuality(Item item, int amount = 1)
    {
        if (item.Quality > 0 && item.Name != Sulfuras)
        {
            item.Quality -= amount;
        }
    }

    private void UpdateAgedBrie(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality++;
        }
    }

    private void UpdateBackstagePasses(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality++;
            if (item.SellIn < 11 && item.Quality < 50)
            {
                item.Quality++;
            }
            if (item.SellIn < 6 && item.Quality < 50)
            {
                item.Quality++;
            }
        }
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            var item = Items[i];
            if (item.Name == AgedBrie)
            {
                UpdateAgedBrie(item);
            }
            else if (item.Name == BackstagePasses)
            {
                UpdateBackstagePasses(item);
            }
            else
            {
                DegradeQuality(item);
            }

            if (item.Name != Sulfuras)
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name == AgedBrie)
                {
                    UpdateAgedBrie(item);
                }
                else if (item.Name == BackstagePasses)
                {
                    item.Quality = 0;
                }
                else
                {
                    DegradeQuality(item);
                }
            }
        }
    }
}