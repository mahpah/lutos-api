using System;

namespace Lutos.Domain.Aggregates.Common
{
    public class Money
    {
        public Currency Currency { get; set; }
        public int Amount { get; set; }

        public Money(int amount, Currency currency)
        {
            Amount = amount >= 0
                ? amount
                : throw new ArgumentException("Amount cannot have negative value", nameof(amount));
            Currency = currency;
        }

        public Money(int amount) : this(amount, Currency.Usd)
        {

        }
    }
}
