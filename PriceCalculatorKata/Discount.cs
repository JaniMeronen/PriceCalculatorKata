namespace PriceCalculatorKata
{
    abstract record Discount
    {
        public abstract Money Apply(Product product);
    }
}