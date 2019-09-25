using System;
using System.Linq;
using System.Threading.Tasks;
using Lutos.Domain.Aggregates.BookAggregate;
using Lutos.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Lutos.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LutosDbContext _dbContext;

        public BookRepository(LutosDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Book> Get(string isbn)
        {
            return _dbContext.Books.Where(t => t.Isbn == isbn).FirstOrDefaultAsync();
        }
    }
}
