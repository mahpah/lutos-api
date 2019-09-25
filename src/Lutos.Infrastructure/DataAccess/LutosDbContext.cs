using System.Reflection;
using Lutos.Domain.Aggregates.BookAggregate;
using Microsoft.EntityFrameworkCore;

namespace Lutos.Infrastructure.DataAccess
{
    public class LutosDbContext  : DbContext
    {
        public LutosDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookCopy> BookCopies { get; set; }
    }
}
