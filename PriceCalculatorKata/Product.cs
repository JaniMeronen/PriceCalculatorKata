using System.Collections.Generic;
using System.Linq;
using static PriceCalculatorKata.Common.PercentageCalculator;

namespace PriceCalculatorKata
{
    record Product(string Name, decimal Price, int Upc)
    {
        public Receipt CreateReceipt(Discount afterTaxDiscount, Discount beforeTaxDiscount, IEnumerable<Expense> expenses, int tax)
        {
            var beforeTaxDiscountAmount = beforeTaxDiscount.Apply(this);
            var discountedProduct = this with { Price = Price - beforeTaxDiscountAmount };
            var taxAmount = Calculate(Price - beforeTaxDiscountAmount, tax);
            var afterTaxDiscountAmount = afterTaxDiscount.Apply(discountedProduct);
            var discountAmount = beforeTaxDiscountAmount + afterTaxDiscountAmount;
            var costs = expenses.Select(expense => expense.CalculateCost(Price));
            var expensesAmount = costs.Aggregate(0M, (total, expense) => total + expense.Amount);
            var total = Price + taxAmount - discountAmount + expensesAmount;
            return new(Price, discountAmount, costs, taxAmount, total);
        }
    }
}