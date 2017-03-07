namespace RQEnchant.Core
{
    public class EnchElementData
    {
        public string Name { get; private set; }
        public double TotalCount { get; set; }
        public double TotalPrice => TotalCount * Price;
        public readonly double Price;
        public EnchElementData(double price, string name)
        {
            Price = price;
            Name = name;
        }
    }
}