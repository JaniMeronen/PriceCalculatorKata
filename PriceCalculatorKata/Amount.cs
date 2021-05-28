namespace PriceCalculatorKata
{
    abstract record Amount
    {
        public abstract decimal Calculate(decimal price);
    }
}