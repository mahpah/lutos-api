using Lutos.Domain.Aggregates.Common;

namespace Lutos.Domain.Services
{
    public interface IBankService
    {
        decimal GetConversionRate(Currency from, Currency to);
    }
}
