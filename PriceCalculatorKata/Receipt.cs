using System.Collections.Generic;

namespace PriceCalculatorKata
{
    record Receipt(Money Cost, Money Discounts, IEnumerable<Cost> Costs, Money Tax, Money Total);
}