using PriceCalculatorKata;
using PriceCalculatorKata.Discounts;
using static System.Console;

var sample = new Product("The Little Prince", 20.25M, 12345);
var universalDiscount = new UniversalDiscount(15);
var upcDiscount = new UpcDiscount(7, 12345);
var receipt = sample.CreateReceipt(universalDiscount, upcDiscount, 20);
WriteLine($"${receipt.PriceAfter}");
if (receipt.DiscountAmount > 0M) WriteLine($"${receipt.DiscountAmount}");