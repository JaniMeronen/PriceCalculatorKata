namespace PriceCalculatorKata
{
    abstract record Amount
    {
        public abstract Money Calculate(Money price);
    }
}