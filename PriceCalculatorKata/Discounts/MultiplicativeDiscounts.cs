namespace PriceCalculatorKata.Discounts
{
    record MultiplicativeDiscounts(Discount First, Discount Second) : Discount
    {
        public override Money Apply(Product product)
        {
            var firstDiscountAmount = First.Apply(product);
            var discountedPrice = product.Price - firstDiscountAmount;
            var discountedProduct = product with { Price = discountedPrice };
            var secondDiscountAmount = Second.Apply(discountedProduct);
            return firstDiscountAmount + secondDiscountAmount;
        }
    }
}