namespace PriceCalculatorKata
{
    static class DecimalExtensions
    {
        public static decimal Round(this decimal d, int decimals) => decimal.Round(d, decimals);
    }
}