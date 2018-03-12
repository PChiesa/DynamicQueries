using System;
using System.Linq;

namespace DynamicQueries
{
    public abstract class BaseCriteria<T>
    {
        public abstract IQueryable<T> ApplyCriteria(IQueryable<T> query);
    }
}
