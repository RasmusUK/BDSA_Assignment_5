namespace GildedRose.Console
{
    public class LegendaryItem : Item
    {
        public override int Quality { get; set; }

        public override void UpdateQuality()
        {
            if(Quality < 50) Quality++;
        }
    }
}