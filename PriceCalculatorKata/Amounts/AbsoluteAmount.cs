namespace PriceCalculatorKata.Amounts
{
    record AbsoluteAmount(Money Value) : Amount
    {
        public override Money Calculate(Money price) => Value;
    }
}