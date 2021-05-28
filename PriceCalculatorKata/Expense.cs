namespace PriceCalculatorKata
{
    record Expense(Amount Amount, string Description)
    {
        public Cost CalculateCost(Money price) => new(Amount.Calculate(price), Description);
    }
}