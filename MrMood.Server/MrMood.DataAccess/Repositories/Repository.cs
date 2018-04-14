using MrMood.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MrMood.DataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DbSet<T> Set;
        private readonly IQueryable<T> QueryableSet;

        protected Repository(DbSet<T> set)
        {
            Set = set;
            QueryableSet = set;
        }

        protected Repository(DbSet<T> set, IQueryable<T> includableSet)
        {
            Set = set;
            QueryableSet = includableSet;
        }

        public T Get(int id) => QueryableSet.FirstOrDefault(e => e.Id == id);
        
        public IEnumerable<T> Get<TKey>(
            Expression<Func<T, bool>> query, 
            Expression<Func<T, TKey>> orderBy,
            int skip,
            int take)
        {
            return QueryableSet
                .Where(query)
                .OrderBy(orderBy)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> query)
        {
            return QueryableSet
               .Where(query)
               .ToList();
        }

        public IEnumerable<T> Get(int take, int skip)
        {
            return QueryableSet
                .OrderBy(e => e.Id)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public IEnumerable<T> Get() => QueryableSet.ToList();

        public void Insert(T item) => Set.Add(item);

        public void Remove(int id) => Set.Remove(Set.First(e => e.Id == id));

        public void Remove(T item) => Set.Remove(item);

        public abstract void Update(int id, T newItem);
    }
}
