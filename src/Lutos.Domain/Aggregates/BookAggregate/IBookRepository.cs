using System;
using System.Threading.Tasks;

namespace Lutos.Domain.Aggregates.BookAggregate
{
    public interface IBookRepository
    {
        Task<Book> Get(string isbn);
    }
}
