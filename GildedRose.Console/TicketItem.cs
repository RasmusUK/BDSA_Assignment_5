namespace GildedRose.Console
{
    public class TicketItem : Item
    {
        public override void UpdateQuality()
        {
            if (SellIn <= 0) Quality = 0;
            else if (SellIn <= 5) Quality = Quality + 3; 
            else if (SellIn <= 10) Quality = Quality + 2;
            else if (SellIn > 10) Quality++;
            
            SellIn--;
        }
    }
}