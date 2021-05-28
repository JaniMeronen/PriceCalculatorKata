namespace PriceCalculatorKata.Discounts
{
    record UniversalDiscount(int Percentage) : Discount
    {
        public override Money Apply(Product product) => product.Price.Scale(Percentage);
    }
}