using PriceCalculatorKata;
using PriceCalculatorKata.Amounts;
using PriceCalculatorKata.Discounts;
using static System.Console;

var sample = new Product("The Little Prince", new(20.25M, "USD"), 12345);
var universalDiscount = new UniversalDiscount(15);
var upcDiscount = new UpcDiscount(7, 12345);
var afterTaxDiscount = new MultiplicativeDiscounts(universalDiscount, upcDiscount);

var cap = new RelativeAmount(100);

var expenses = new Expense[] { new(new RelativeAmount(3), "Transport") };

var receipt = sample.CreateReceipt(afterTaxDiscount, new NoDiscount(), cap, expenses, 21);
WriteLine($"Cost = ${receipt.Cost.Round(2)}");
WriteLine($"Tax = ${receipt.Tax.Round(2)}");
if (receipt.Discounts.Any) WriteLine($"Discounts = ${receipt.Discounts.Round(2)}");
foreach (var expense in receipt.Costs) WriteLine($"{expense.Description} ${expense.Amount.Round(2)}");
WriteLine($"TOTAL = ${receipt.Total.Round(2)}");
if (receipt.Discounts.Any) WriteLine($"${receipt.Discounts.Round(2)}");