using System.Threading.Tasks;
using FluentAssertions;
using Lutos.Domain.Aggregates.BookAggregate;
using Lutos.Infrastructure.Repositories;
using Xunit;

namespace Lutos.Tests.Infrastructure
{
    [Collection("DbContext")]
    public class BookRepositoryTests
    {
        private readonly DbContextFixture _fixture;
        private readonly IBookRepository _sut;

        public BookRepositoryTests(DbContextFixture fixture)
        {
            _fixture = fixture;
            _sut = new BookRepository(fixture.Context);
        }

        [Fact]
        public async Task should_get_book_by_isbn()
        {
            var book = await _sut.Get(_fixture.FirstBookIsbn);
            book.Should().NotBeNull();
            book.Isbn.Should().Be(_fixture.FirstBookIsbn);
        }
    }
}
