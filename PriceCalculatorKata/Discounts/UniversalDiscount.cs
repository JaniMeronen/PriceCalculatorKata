using static PriceCalculatorKata.Common.PercentageCalculator;

namespace PriceCalculatorKata.Discounts
{
    record UniversalDiscount(int Percentage) : Discount
    {
        public override decimal Apply(Product product) => Calculate(product.Price, Percentage);
    }
}