using PriceCalculatorKata.Common;
using static PriceCalculatorKata.Common.PercentageCalculator;

namespace PriceCalculatorKata
{
    record Product(string Name, decimal Price, int Upc)
    {
        public Receipt CreateReceipt(Discount discount, int tax)
        {
            var discountAmount = discount.Apply(this).Round(2);
            var taxAmount = Calculate(Price, tax).Round(2);
            var priceAfter = (Price + taxAmount - discountAmount).Round(2);
            return new(discountAmount, priceAfter, Price, taxAmount);
        }
    }
}