using System;

namespace Lutos.Domain.Aggregates.BookAggregate
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Isbn { get; private set; }
        public string Title { get; private set; }
    }
}
