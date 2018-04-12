using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MrMood.DataAccess.Repositories
{
    public interface ISimpleRepository<T>
    {
        void Insert(T item);

        IEnumerable<T> Get(Expression<Func<T, bool>> query);

        void Remove(Expression<Func<T, bool>> query);
    }
}
