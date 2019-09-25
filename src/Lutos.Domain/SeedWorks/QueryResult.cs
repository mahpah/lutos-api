using System.Collections.Generic;

namespace Lutos.Domain.SeedWorks
{
    public class QueryResult<T>
    {
        public IList<T> Items { get; set; }
        public long Count { get; set; }
    }
}
