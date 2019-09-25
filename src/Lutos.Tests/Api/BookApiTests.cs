using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Lutos.Api;
using Lutos.Domain.Aggregates.BookAggregate;
using Lutos.Domain.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Lutos.Tests.Api
{
    [Collection("API")]
    public class BookApiTests
    {
        private readonly ApiServerFactory _factory;
        private readonly HttpClient _client;

        public BookApiTests(ApiServerFactory factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task list_api_should_response_ok()
        {
            var response = await _client.GetAsync("api/v1/books");
            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var payload = await response.Content.ReadAsAsync<QueryResult<Book>>();
            payload.Count.Should().Be(20);
            payload.Items.Should().HaveCount(10);
        }
    }
}
