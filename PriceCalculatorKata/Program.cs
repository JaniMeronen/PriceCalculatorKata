using PriceCalculatorKata;
using PriceCalculatorKata.Amounts;
using PriceCalculatorKata.Common;
using PriceCalculatorKata.Discounts;
using static System.Console;

var sample = new Product("The Little Prince", 20.25M, 12345);
var universalDiscount = new UniversalDiscount(15);
var upcDiscount = new UpcDiscount(7, 12345);
var afterTaxDiscount = new ComplexDiscount(universalDiscount, upcDiscount);

var expenses = new Expense[]
{
    //new(new RelativeAmount(1), "Packaging"),
    //new(new AbsoluteAmount(2.2M), "Transport")
};

var receipt = sample.CreateReceipt(new NoDiscount(), new NoDiscount(), expenses, 21);
WriteLine($"Cost = ${receipt.Cost.Round(2)}");
WriteLine($"Tax = ${receipt.Tax.Round(2)}");
if (receipt.Discounts > 0M) WriteLine($"Discounts = ${receipt.Discounts.Round(2)}");
foreach (var expense in receipt.Costs) WriteLine($"{expense.Description} ${expense.Amount.Round(2)}");
WriteLine($"TOTAL = ${receipt.Total.Round(2)}");
if (receipt.Discounts > 0M) WriteLine($"${receipt.Discounts.Round(2)}");