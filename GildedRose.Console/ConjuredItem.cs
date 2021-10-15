namespace GildedRose.Console
{
    public class ConjuredItem : Item
    {
        public override void UpdateQuality()
        {
            if (SellIn <= 0) Quality = Quality -4;
            else Quality = Quality - 2;
            SellIn--;
        }
    }
}