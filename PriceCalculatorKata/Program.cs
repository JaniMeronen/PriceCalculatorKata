using PriceCalculatorKata;
using PriceCalculatorKata.Discounts;
using static System.Console;

var sample = new Product("The Little Prince", 20.25M, 12345);
var universalDiscount = new UniversalDiscount(15);
var upcDiscount = new UpcDiscount(7, 789);
var complexDiscount = new ComplexDiscount(universalDiscount, upcDiscount);
var receipt = sample.CreateReceipt(complexDiscount, 21);
WriteLine($"${receipt.PriceAfter}");
if (receipt.DiscountAmount > 0M) WriteLine($"${receipt.DiscountAmount}");