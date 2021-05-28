using System.Collections.Generic;
using System.Linq;

namespace PriceCalculatorKata
{
    record Product(string Name, Money Price, int Upc)
    {
        public Receipt CreateReceipt(Discount afterTaxDiscount, Discount beforeTaxDiscount, Amount Cap, IEnumerable<Expense> expenses, int tax)
        {
            var beforeTaxDiscountAmount = beforeTaxDiscount.Apply(this);
            var discountedPrice = Price - beforeTaxDiscountAmount;
            var discountedProduct = this with { Price = discountedPrice };
            var taxAmount = discountedPrice.Scale(tax);
            var afterTaxDiscountAmount = afterTaxDiscount.Apply(discountedProduct);
            var uncappedDiscountAmount = beforeTaxDiscountAmount + afterTaxDiscountAmount;
            var cappedDiscountAmount = Cap.Calculate(Price);
            var discountAmount = uncappedDiscountAmount.Min(cappedDiscountAmount);
            var costs = expenses.Select(expense => expense.CalculateCost(Price));
            var costsAmount = costs.Aggregate(Price.Zero, (total, expense) => total + expense.Amount);
            var total = Price + taxAmount - discountAmount + costsAmount;
            return new(Price, discountAmount, costs, taxAmount, total);
        }
    }
}