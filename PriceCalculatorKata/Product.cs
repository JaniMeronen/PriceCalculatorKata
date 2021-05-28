using System;
using System.Collections.Generic;
using System.Linq;
using static PriceCalculatorKata.Common.PercentageCalculator;

namespace PriceCalculatorKata
{
    record Product(string Name, decimal Price, int Upc)
    {
        public Receipt CreateReceipt(Discount afterTaxDiscount, Discount beforeTaxDiscount, Amount Cap, IEnumerable<Expense> expenses, int tax)
        {
            var beforeTaxDiscountAmount = beforeTaxDiscount.Apply(this);
            var discountedProduct = this with { Price = Price - beforeTaxDiscountAmount };
            var taxAmount = Calculate(Price - beforeTaxDiscountAmount, tax);
            var afterTaxDiscountAmount = afterTaxDiscount.Apply(discountedProduct);
            var uncappedDiscountAmount = beforeTaxDiscountAmount + afterTaxDiscountAmount;
            var cappedDiscountAmount = Math.Min(uncappedDiscountAmount, Cap.Calculate(Price));
            var costs = expenses.Select(expense => expense.CalculateCost(Price));
            var expensesAmount = costs.Aggregate(0M, (total, expense) => total + expense.Amount);
            var total = Price + taxAmount - cappedDiscountAmount + expensesAmount;
            return new(Price, cappedDiscountAmount, costs, taxAmount, total);
        }
    }
}