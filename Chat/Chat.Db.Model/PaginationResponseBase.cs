using System.Collections.Generic;

namespace Chat.Db.Model
{
    public abstract class PaginationResponseBase<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}
