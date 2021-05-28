using PriceCalculatorKata;
using static System.Console;

var sample = new Product("The Little Prince", 20.25M, 12345);
var receipt = sample.CreateReceipt(0, 20);
WriteLine($"${receipt.PriceAfter}");
if (receipt.DiscountAmount > 0M) WriteLine($"${receipt.DiscountAmount}");