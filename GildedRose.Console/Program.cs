using System.Collections.Generic;
using System;

namespace GildedRose.Console
{
    public class Program
    {
        public List<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                                              new DefaultItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new BetterWithTimeItem {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new DefaultItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new LegendaryItem() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new TicketItem
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              //new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }
                          };
            app.UpdateAllQualities();

            System.Console.ReadKey();

        }

        public void UpdateAllQualities() => Items.ForEach(i => i.UpdateQuality());
    }
}