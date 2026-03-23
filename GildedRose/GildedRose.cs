using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    private const string AgedBrie = "Aged Brie";
    private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
    private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
    // No longer need a specific Conjured constant; handled by prefix match

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    private static readonly Dictionary<string, IItemUpdater> Updaters = new()
    {
        { AgedBrie, new AgedBrieUpdater() },
        { BackstagePasses, new BackstagePassesUpdater() },
        { Sulfuras, new SulfurasUpdater() }
    };

    private static IItemUpdater GetUpdater(Item item)
    {
        // Handle any item whose name starts with "Conjured" (case-insensitive)
        if (item.Name != null && item.Name.StartsWith("Conjured", System.StringComparison.OrdinalIgnoreCase))
        {
            return new ConjuredItemUpdater();
        }
        if (Updaters.TryGetValue(item.Name, out var updater))
        {
            return updater;
        }
        return new NormalItemUpdater();
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            GetUpdater(item).Update(item);
        }
    }
}