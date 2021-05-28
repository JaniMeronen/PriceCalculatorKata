namespace PriceCalculatorKata
{
    record Receipt(int Discount, decimal DiscountAmount, decimal PriceAfter, decimal PriceBefore, int Tax, decimal TaxAmount);
}