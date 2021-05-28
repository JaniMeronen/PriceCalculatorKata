namespace PriceCalculatorKata.Discounts
{
    record AdditiveDiscounts(Discount First, Discount Second) : Discount
    {
        public override Money Apply(Product product) => First.Apply(product) + Second.Apply(product);
    }
}