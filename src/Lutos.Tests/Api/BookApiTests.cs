using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Lutos.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Lutos.Tests.Api
{
    public class BookApiTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public BookApiTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task list_api_should_response_ok()
        {
            var response = await _client.GetAsync("api/v1/books");
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
