using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models.FilterModels
{
    public class FilterBase<T>
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }

        public virtual IQueryable<T> Filter(IQueryable<T> query)
        {
            if (Skip.HasValue)
            {
                query = query.Skip(Skip.Value);
            }
            if (Take.HasValue)
            {
                query = query.Take(Take.Value);
            }
            return query;
        }
    }
}
