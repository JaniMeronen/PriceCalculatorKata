namespace PriceCalculatorKata.Discounts
{
    record NoDiscount : Discount
    {
        public override Money Apply(Product product) => product.Price.Zero;
    }
}