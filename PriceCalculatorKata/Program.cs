using PriceCalculatorKata;
using static System.Console;

var sample = new Product("The Little Prince", 20.25M, 12345);

WriteLine($"Sample product: Book with name = “{sample.Name}”, UPC = {sample.Upc}, price = ${sample.Price}.");
WriteLine();

var receipt = sample.CreateReceipt(15, 20);

WriteLine($"Tax = {receipt.Tax} %, discount = {receipt.Discount} %");
WriteLine($"Tax amount = ${receipt.TaxAmount}, Discount amount = ${receipt.DiscountAmount}");
WriteLine($"Price before = ${receipt.PriceBefore}, price after = ${receipt.PriceAfter}");