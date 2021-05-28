using PriceCalculatorKata;
using static System.Console;

var sample = new Product("The Little Prince", 20.25M, 12345);

WriteLine($"Sample product: Book with name = “{sample.Name}”, UPC = {sample.Upc}, price = ${sample.Price}.");
WriteLine();

var rate1 = 20;
var taxedProduct1 = sample.ApplyTax(rate1);
WriteLine($"Product price reported as ${sample.Price} before tax and ${taxedProduct1.Price} after {rate1}% tax.");

var rate2 = 21;
var taxedProduct2 = sample.ApplyTax(rate2);
WriteLine($"Product price reported as ${sample.Price} before tax and ${taxedProduct2.Price} after {rate2}% tax.");