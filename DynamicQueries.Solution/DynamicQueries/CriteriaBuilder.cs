using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicQueries
{
    public struct CriteriaBuilder<T>
    {
        private BaseCriteria<T>[] _criterias;

        public CriteriaBuilder(params BaseCriteria<T>[] criterias)
        {
            _criterias = criterias;
        }

        public IQueryable<T> Build(IQueryable<T> query)
        {
            foreach (var criteria in _criterias)
            {
                query = criteria.ApplyCriteria(query);
            }

            return query;
        }

        public T Materialize(IQueryable<T> query)
        {
            return query.FirstOrDefault();
        }

        public List<T> MaterializeList(IQueryable<T> query)
        {
            return query.ToList();
        }
    }
}
