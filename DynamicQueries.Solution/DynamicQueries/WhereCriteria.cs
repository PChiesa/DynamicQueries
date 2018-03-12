using System;
using System.Linq;
using System.Linq.Expressions;

namespace DynamicQueries
{
    public class WhereCriteria<T> : BaseCriteria<T>
    {
        private CriteriaParameters _criteriaParams;

        public WhereCriteria(CriteriaParameters criteriaParameters)
        {
            _criteriaParams = criteriaParameters;
        }

        public override IQueryable<T> ApplyCriteria(IQueryable<T> query)
        {

            if (_criteriaParams.SingleProperty != null)
            {
                /*query.Where(x => x.ParamName == ParamValue)*/
                var param = Expression.Parameter(typeof(T), "x");

                Expression expression = Expression.Empty();

                foreach (var property in _criteriaParams.SingleProperty)
                {

                    Expression equalExpression;

                    if (property.Key.Length == 0)
                    {
                        equalExpression = Expression.Equal(param, Expression.Constant(property.Value, property.Value.GetType()));
                    }
                    else
                    {
                        equalExpression = Expression.Equal(Expression.Property(param, property.Key), Expression.Constant(property.Value, property.Value.GetType()));
                    }

                    expression = equalExpression;
                }

                //MethodCallExpression whereCallExpression = Expression.Call(
                //    typeof(Queryable),
                //    "Where",
                //    new Type[] { query.ElementType },
                //    query.Expression,
                //    Expression.Lambda<Func<T, bool>>(expression, new ParameterExpression[] { param }));

                //return query.Provider.CreateQuery<T>(expression);

                Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(expression, param);

                return query.Where(lambda);
            }

            return query;

            if (_criteriaParams.MultiProperty != null)
            {


            }


        }
    }
}
