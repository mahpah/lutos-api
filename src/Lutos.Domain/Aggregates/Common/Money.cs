using System;

namespace Lutos.Domain.Aggregates.Common
{
    public class Money : IEquatable<Money>
    {
        public Currency Currency { get; private set; }
        public decimal Amount { get; private set; }

        public Money(decimal amount, Currency currency)
        {
            Amount = amount >= 0
                ? amount
                : throw new ArgumentException("Amount cannot have negative value", nameof(amount));
            Currency = currency;
        }

        public Money(decimal amount) : this(amount, Currency.Usd)
        {

        }

        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Currency == other.Currency && Amount == other.Amount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Currency * 397) ^ Amount.GetHashCode();
            }
        }
    }
}
