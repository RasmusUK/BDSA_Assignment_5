namespace GildedRose.Console
{
    public class DefaultItem : Item
    {
        public override void UpdateQuality()
        {
            if (SellIn <= 0) Quality = Quality - 2;
            else Quality--;
            SellIn--;
        }
    }
}