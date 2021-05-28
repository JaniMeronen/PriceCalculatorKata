namespace PriceCalculatorKata.Discounts
{
    record UpcDiscount(int Percentage, int Upc) : Discount
    {
        public override Money Apply(Product product) => product.Upc == Upc ? product.Price.Scale(Percentage) : product.Price.Zero;
    }
}