namespace PriceCalculatorKata.Amounts
{
    record RelativeAmount(int Percentage) : Amount
    {
        public override Money Calculate(Money price) => price.Scale(Percentage);
    }
}