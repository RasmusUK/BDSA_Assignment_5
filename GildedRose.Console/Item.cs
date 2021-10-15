namespace GildedRose.Console
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public virtual int Quality
        {
            get => _quality;
            set
            {
                
                if (value > 50) _quality = 50;
                else if (value < 0) _quality = 0;
                else _quality = value;
            }
        }

        private int _quality;
        
        public abstract void UpdateQuality();
    }
}