using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Security;
using System.Text;

namespace Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
            Includes = new List<Expression<Func<T, object>>>();
        }

        public BaseSpecification()
        {
            Includes = new List<Expression<Func<T, object>>>();
        }

        public Expression<Func<T, bool>> Criteria { get;  }

        public List<Expression<Func<T, object>>> Includes { get; }

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> OrderByExpression)
        {
            OrderBy = OrderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> OrderByExpression)
        {
            OrderByDescending = OrderByDescending;
        }
    }
}
