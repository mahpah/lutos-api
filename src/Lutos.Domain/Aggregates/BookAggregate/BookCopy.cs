using System;
using Lutos.Domain.Aggregates.Common;

namespace Lutos.Domain.Aggregates.BookAggregate
{
    public class BookCopy
    {
        public Guid Id { get; private set; }

        public Guid OwnerId { get; private set; }

        public Guid BookId { get; private set; }
        public virtual Book Book { get; private set; }

        public Money Price { get; private set; }
    }
}
