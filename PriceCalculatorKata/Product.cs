using System.Collections.Generic;
using System.Linq;

namespace PriceCalculatorKata
{
    record Product(string Name, Money Price, int Upc)
    {
        public Receipt CreateReceipt(Discount afterTaxDiscount, Discount beforeTaxDiscount, Amount Cap, IEnumerable<Expense> expenses, int tax)
        {
            var beforeTaxDiscountAmount = beforeTaxDiscount.Apply(this).Round(4);
            var discountedPrice = (Price - beforeTaxDiscountAmount).Round(4);
            var discountedProduct = this with { Price = discountedPrice };
            var taxAmount = discountedPrice.Scale(tax).Round(4);
            var afterTaxDiscountAmount = afterTaxDiscount.Apply(discountedProduct).Round(4);
            var uncappedDiscountAmount = (beforeTaxDiscountAmount + afterTaxDiscountAmount).Round(4);
            var cappedDiscountAmount = Cap.Calculate(Price).Round(4);
            var discountAmount = uncappedDiscountAmount.Min(cappedDiscountAmount);
            var costs = expenses.Select(expense => expense.CalculateCost(Price));
            var costsAmount = costs.Aggregate(Price.Zero, (total, expense) => total + expense.Amount.Round(4));
            var total = (Price + taxAmount - discountAmount + costsAmount).Round(4);
            return new(Price, discountAmount, costs, taxAmount, total);
        }
    }
}