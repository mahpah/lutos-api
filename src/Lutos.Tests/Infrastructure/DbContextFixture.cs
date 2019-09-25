using System.Collections.Generic;
using System.Linq;
using GenFu;
using Lutos.Domain.Aggregates.BookAggregate;
using Lutos.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Lutos.Tests.Infrastructure
{
    public class DbContextFixture
    {
        public LutosDbContext Context { get; }
        public string FirstBookIsbn { get; set; }

        public DbContextFixture()
        {
            var bookList = GetFakeData();
            FirstBookIsbn = bookList.Select(t => t.Isbn).First();

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase("test_lutos");
            Context = new LutosDbContext(optionsBuilder.Options);
            Context.Books.AddRange(bookList);
            Context.SaveChanges();
        }

        private IEnumerable<Book> GetFakeData()
        {
            return A.ListOf<Book>(20).AsReadOnly();
        }
    }

    [CollectionDefinition("DbContext")]
    public class DbContextCollection : ICollectionFixture<DbContextFixture>
    {
    }
}
