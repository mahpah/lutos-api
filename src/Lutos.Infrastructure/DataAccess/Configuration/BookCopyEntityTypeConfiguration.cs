using Lutos.Domain.Aggregates.BookAggregate;
using Lutos.Domain.Aggregates.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Lutos.Infrastructure.DataAccess.Configuration
{
    public class BookCopyEntityTypeConfiguration : IEntityTypeConfiguration<BookCopy>
    {
        public void Configure(EntityTypeBuilder<BookCopy> builder)
        {
            builder.Property(t => t.Price)
                .HasConversion(
                    t => JsonConvert.SerializeObject(t),
                    s => JsonConvert.DeserializeObject<Money>(s));
        }
    }
}
