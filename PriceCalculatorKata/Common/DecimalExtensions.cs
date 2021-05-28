namespace PriceCalculatorKata.Common
{
    static class DecimalExtensions
    {
        public static decimal Round(this decimal d, int decimals) => decimal.Round(d, decimals);
    }
}