namespace GildedRose.Console
{
    public class BetterWithTimeItem : Item
    {
        public override void UpdateQuality()
        {
            Quality++;
            SellIn--;
        }
    }
}