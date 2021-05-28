namespace PriceCalculatorKata.Amounts
{
    record AbsoluteAmount(decimal Value) : Amount
    {
        public override decimal Calculate(decimal price) => Value;
    }
}