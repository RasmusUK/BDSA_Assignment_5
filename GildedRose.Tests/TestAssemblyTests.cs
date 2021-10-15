using System;
using System.Collections.Generic;
using GildedRose.Console;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests : IDisposable
    {
        private GildedRose.Console.Program App;
        public TestAssemblyTests()
        {
            var app = new GildedRose.Console.Program()
                {
                    Items = new List<Item>
                    {
                        new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                        new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                        new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                        new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 15,
                            Quality = 20
                        },
                        new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                    }
                };
            App = app;
        }
        

        public void Dispose()
        {
            App = null;
        }
        
        [Fact]
        public void DexterityVestAfter20WeeksQualityZero()
        {
            for (int i = 0; i < 21; i++)
            {
                App.UpdateQuality();
            }
            var expected = 0;
            var actual = App.Items[0].Quality;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void DexterityVestAfter20WeeksSellInNegative()
        {
            for (int i = 0; i < 21; i++)
            {
                App.UpdateQuality();
            }
            var expected = -11;
            var actual = App.Items[0].SellIn;
            Assert.Equal(expected,actual);
        }
    
        [Fact]
        public void DexterityVestLose1QualityAfter1Week()
        {
            App.UpdateQuality();
            var expected = 19;
            var actual = App.Items[0].Quality;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void DexterityVestLose1SellinAfter1Week()
        {
            App.UpdateQuality();
            var expected = 9;
            var actual = App.Items[0].SellIn;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void DexterityVestLose2QualityAfter1WeekAfterQualityIsZero()
        {
            for (int i = 0; i < 11; i++)
            {
                App.UpdateQuality();
            }
            var expected = 8;
            var actual = App.Items[0].Quality;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void BrieIncrease1QualityAfter1Week()
        {
            App.UpdateQuality();
            var expected = 1;
            var actual = App.Items[1].Quality;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void BrieLose1SellinAfter1Week()
        {
            App.UpdateQuality();
            var expected = 1;
            var actual = App.Items[1].SellIn;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void BrieIncreaseQualityToMaxOf50After60Weeks()
        {
            for (int i = 0; i < 61; i++)
            {
                App.UpdateQuality();
            }
            var expected = 50;
            var actual = App.Items[1].Quality;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void ElixierLose1QualityAfter1Week()
        {
            App.UpdateQuality();
            var expected = 6;
            var actual = App.Items[2].Quality;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void ElixierLose1SellinAfter1Week()
        {
            App.UpdateQuality();
            var expected = 4;
            var actual = App.Items[2].SellIn;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void ElixierLose2QualityAfter1WeekAfterQualityIsZero()
        {
            for (int i = 0; i < 6; i++)
            {
                App.UpdateQuality();
            }
            var expected = 0;
            var actual = App.Items[2].Quality;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void HandNoSellin()
        {
            App.UpdateQuality();
            var expected = 0;
            var actual = App.Items[3].SellIn;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void HandQualityAfter1WeekSameAsBefore80()
        {
            App.UpdateQuality();
            var expected = 80;
            var actual = App.Items[3].Quality;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void HandQualityAfter20WeeksSameAsBefore80()
        {
            for (int i = 0; i < 21; i++)
            {
                App.UpdateQuality();
            }
            var expected = 80;
            var actual = App.Items[3].Quality;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void BackStagePassIncreaseQuality1WhenSellInAbove10()
        {
            App.UpdateQuality();
            var expected = 21;
            var actual = App.Items[4].Quality;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void BackStagePassIncreaseQuality2WhenSellInBetween5And10()
        {
            for (int i = 0; i < 7; i++)
            {
                App.UpdateQuality();
            }
            var expected = 29;
            var actual = App.Items[4].Quality;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void BackStagePassIncreaseQuality2WhenSellIn10()
        {
            for (int i = 0; i < 6; i++)
            {
                App.UpdateQuality();
            }
            var expected = 27;
            var actual = App.Items[4].Quality;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void BackStagePassIncreaseQuality3WhenSellIn5()
        {
            for (int i = 0; i < 11; i++)
            {
                App.UpdateQuality();
            }
            var expected = 38;
            var actual = App.Items[4].Quality;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void BackStagePassIncreaseQuality3WhenSellInBetween5And0()
        {
            for (int i = 0; i < 12; i++)
            {
                App.UpdateQuality();
            }
            var expected = 41;
            var actual = App.Items[4].Quality;
            Assert.Equal(expected,actual);
        }
        
        [Fact]
        public void BackStagePassQuality0AfterConcert()
        {
            for (int i = 0; i < 16; i++)
            {
                App.UpdateQuality();
            }
            var expected = 0;
            var actual = App.Items[4].Quality;
            Assert.Equal(expected,actual);
        }
        
        /*
        [Fact]
        public void ConjuredLose2QualityAfter1WeekBeforeSellin()
        {
            App.UpdateQuality();
            var expected = 4;
            var actual = App.Items[5].Quality;
            Assert.Equal(expected,actual);
        }
        */
    
    }
}