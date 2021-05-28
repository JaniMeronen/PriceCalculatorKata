using static PriceCalculatorKata.Common.PercentageCalculator;

namespace PriceCalculatorKata.Discounts
{
    record UpcDiscount(int Percentage, int Upc) : Discount
    {
        public override decimal Apply(Product product) => product.Upc == Upc ? Calculate(product.Price, Percentage) : 0M;
    }
}