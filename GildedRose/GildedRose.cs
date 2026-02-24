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

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            var item = Items[i];
            if (item.Name != AgedBrie && item.Name != BackstagePasses)
            {
                DegradeQuality(item);
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == BackstagePasses)
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (item.Name != Sulfuras)
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != AgedBrie)
                {
                    if (item.Name != BackstagePasses)
                    {
                        DegradeQuality(item);
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }
    }
}