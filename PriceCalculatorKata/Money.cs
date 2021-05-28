using System;

namespace PriceCalculatorKata
{
    record Money(decimal Amount, string Currency)
    {
        public bool Any => Amount > 0M;

        public Money Zero => this with { Amount = 0M };

        public Money Min(Money other) => Currency == other.Currency ? Amount > other.Amount ? other : this : throw new InvalidOperationException("Currency mismatch");

        public Money Round(int decimals) => this with { Amount = decimal.Round(Amount, decimals) };

        public Money Scale(decimal percentage) => percentage == 0 ? this : this with { Amount = Amount * (percentage / 100M) };

        public override string ToString() => $"{Amount:0.00} {Currency}";

        public static Money operator +(Money left, Money right) =>
            left.Currency == right.Currency ? left with { Amount = left.Amount + right.Amount } :
            throw new InvalidOperationException("Currency mismatch");

        public static Money operator -(Money left, Money right) =>
            left.Currency == right.Currency ? left with { Amount = left.Amount - right.Amount } :
            throw new InvalidOperationException("Currency mismatch");
    }
}