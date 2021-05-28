using static System.Decimal;

namespace PriceCalculatorKata
{
    record Product(string Name, decimal Price, int Upc)
    {
        public Product ApplyTax(int rate)
        {
            if (rate == 0) return this;
            var factor = rate / 100M;
            var taxAmount = Price * factor;
            var taxedPrice = Price + taxAmount;
            var roundedPrice = Round(taxedPrice, 2);
            return this with { Price = roundedPrice };
        }
    }
}