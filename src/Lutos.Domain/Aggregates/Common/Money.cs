namespace Lutos.Domain.Aggregates.Common
{
    public class Money
    {
        public Currency Currency { get; set; }
        public int Amount { get; set; }

        public Money(int amount, Currency currency)
        {

        }

        public Money(int amount)
        {

        }
    }
}
