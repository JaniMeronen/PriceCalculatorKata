using PriceCalculatorKata.Common;

namespace PriceCalculatorKata.Amounts
{
    record RelativeAmount(int Percentage) : Amount
    {
        public override decimal Calculate(decimal price) => PercentageCalculator.Calculate(price, Percentage);
    }
}