using System.Collections.Generic;

namespace PriceCalculatorKata
{
    record Receipt(decimal Cost, decimal Discounts, IEnumerable<Cost> Costs, decimal Tax, decimal Total);
}