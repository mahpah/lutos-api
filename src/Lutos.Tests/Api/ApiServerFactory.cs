using System;
using System.Collections.Generic;
using GenFu;
using Lutos.Api;
using Lutos.Domain.Aggregates.BookAggregate;
using Lutos.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Lutos.Tests.Api
{
    public class ApiServerFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
                {
                    var serviceProvider = new ServiceCollection()
                        .AddEntityFrameworkInMemoryDatabase()
                        .BuildServiceProvider();
                    services.AddDbContext<LutosDbContext>(cfg =>
                    {
                        cfg.UseInMemoryDatabase("lutos-test")
                            .UseInternalServiceProvider(serviceProvider);
                    });

                    var sp = services.BuildServiceProvider();

                    using (var scope = sp.CreateScope())
                    {
                        var context = scope.ServiceProvider.GetService<LutosDbContext>();
                        context.Books.AddRange(GetFakeBookList());
                        context.SaveChanges();
                    }
                });
        }

        private IEnumerable<Book> GetFakeBookList()
        {
            return A.ListOf<Book>(20).AsReadOnly();
        }
    }

    [CollectionDefinition("API")]
    public class ApplicationCollection : ICollectionFixture<ApiServerFactory>
    {

    }
}
