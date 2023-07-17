﻿using CleanArchitecture.Infrastructure.Specifications;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>>? OrderBy { get; private set; }

        public Expression<Func<T, object>>? OrderByDescending { get; private set; }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        protected void ApplyPaging(int pageIndex, int pageSize)
        {
            int skip = pageSize * (pageIndex - 1);
            Skip = skip;
            Take = pageSize;
            IsPagingEnable = true;
        }

        public bool IsPagingEnable {get; private set;}

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        { 
            Includes.Add(includeExpression);
        }

    }
}
