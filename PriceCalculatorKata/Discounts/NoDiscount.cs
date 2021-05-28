namespace PriceCalculatorKata.Discounts
{
    record NoDiscount : Discount
    {
        public override decimal Apply(Product product) => 0M;
    }
}