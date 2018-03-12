using System;
using System.Linq;

namespace DynamicQueries
{
    public class OrderByCriteria<T> : BaseCriteria<T>
    {
        public OrderByCriteria()
        {
        }

        public override IQueryable<T> ApplyCriteria(IQueryable<T> query)
        {
            throw new NotImplementedException();
        }
    }
}
