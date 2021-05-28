namespace PriceCalculatorKata.Common
{
    static class PercentageCalculator
    {
        public static decimal Calculate(decimal off, decimal percentage) => percentage switch
        {
            0 => 0M,
            _ => off * (percentage / 100M)
        };
    }
}