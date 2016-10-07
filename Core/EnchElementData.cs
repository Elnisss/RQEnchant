namespace RQEnchant.Core
{
    public class EnchElementData
    {
        public double TotalCount { get; set; }
        public double TotalPrice => TotalCount * _price;

        private readonly double _price;
        public EnchElementData(double price)
        {
            _price = price;
        }
    }
}