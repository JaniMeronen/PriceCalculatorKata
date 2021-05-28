using static PriceCalculatorKata.PercentageCalculator;

namespace PriceCalculatorKata
{
    record Product(string Name, decimal Price, int Upc)
    {
        public Receipt CreateReceipt(int discount, int tax)
        {
            var discountAmount = Calculate(Price, discount).Round(2);
            var taxAmount = Calculate(Price, tax).Round(2);
            var priceAfter = (Price + taxAmount - discountAmount).Round(2);
            return new(discount, discountAmount, priceAfter, Price, tax, taxAmount);
        }
    }
}