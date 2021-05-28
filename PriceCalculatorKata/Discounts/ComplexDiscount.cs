namespace PriceCalculatorKata.Discounts
{
    record ComplexDiscount(Discount First, Discount Second) : Discount
    {
        public override decimal Apply(Product product) => First.Apply(product) + Second.Apply(product);
    }
}