using System;
using System.Linq;

namespace DynamicQueries
{
    public class AndCriteria<T> : BaseCriteria<T>
    {
        public AndCriteria()
        {
        }

        public override IQueryable<T> ApplyCriteria(IQueryable<T> query)
        {
            throw new NotImplementedException();
        }
    }
}
