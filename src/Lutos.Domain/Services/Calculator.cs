using Lutos.Domain.Aggregates.Common;

namespace Lutos.Domain.Services
{
    public class Calculator
    {
        private readonly IBankService _bankService;

        public Calculator(IBankService bankService)
        {
            _bankService = bankService;
        }
        public int Sum(int v1, int v2)
        {
            return v1 + v2;
        }

        public Money Convert(Money from, Currency toCurrency)
        {
            var amount = from.Amount * _bankService.GetConversionRate(from.Currency, toCurrency);
            return new Money(amount, toCurrency);
        }
    }
}
