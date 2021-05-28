using PriceCalculatorKata.Common;
using static PriceCalculatorKata.Common.PercentageCalculator;

namespace PriceCalculatorKata
{
    record Product(string Name, decimal Price, int Upc)
    {
        public Receipt CreateReceipt(Discount afterTaxDiscount, Discount beforeTaxDiscount, int tax)
        {
            var beforeTaxDiscountAmount = beforeTaxDiscount.Apply(this).Round(2);
            var discountedProduct = this with { Price = Price - beforeTaxDiscountAmount };
            var taxAmount = Calculate(Price - beforeTaxDiscountAmount, tax).Round(2);
            var afterTaxDiscountAmount = afterTaxDiscount.Apply(discountedProduct).Round(2);
            var discountAmount = (beforeTaxDiscountAmount + afterTaxDiscountAmount).Round(2);
            var priceAfter = (Price + taxAmount - discountAmount).Round(2);
            return new(discountAmount, priceAfter, Price, taxAmount);
        }
    }
}