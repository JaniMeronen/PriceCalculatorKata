namespace PriceCalculatorKata
{
    abstract record Discount
    {
        public abstract decimal Apply(Product product);
    }
}