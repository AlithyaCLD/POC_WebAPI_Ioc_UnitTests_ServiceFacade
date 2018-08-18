using System.Collections.Generic;

namespace TR.BusinessLayer.Domain.Common
{
    public class PagedList<T>
        where T : class
    {
        public IList<T> List { get; set; }
        public int ItemCount { get; set; }
    }
}
