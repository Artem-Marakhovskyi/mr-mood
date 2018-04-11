using MrMood.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MrMood.DataAccess.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        void Insert(T item);

        void Remove(int id);

        void Remove(T item);

        Task<T> Get(int id);

        IEnumerable<T> Get<TKey>(
            Expression<Func<T, bool>> query,
            Expression<Func<T,TKey>> orderBy,
            int skip,
            int take);

        IEnumerable<T> Get(Expression<Func<T, bool>> query);

        void Update(int id, T newItem);
    }
}
