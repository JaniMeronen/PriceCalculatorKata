namespace PriceCalculatorKata
{
    record Expense(Amount Amount, string Description)
    {
        public Cost CalculateCost(decimal price) => new(Amount.Calculate(price), Description);
    }
}