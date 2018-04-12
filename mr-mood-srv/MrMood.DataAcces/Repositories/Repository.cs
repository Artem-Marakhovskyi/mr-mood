using Microsoft.EntityFrameworkCore;
using MrMood.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MrMood.DataAccess.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected DbSet<T> Set;

        public Repository(DbSet<T> set)
        {
            Set = set;
        }

        public Task<T> Get(int id)
        {
            return Set.FirstAsync(e => e.Id == id);
        }
        
        public IEnumerable<T> Get<TKey>(
            Expression<Func<T, bool>> query, 
            Expression<Func<T, TKey>> orderBy,
            int skip,
            int take)
        {
            return Set
                .Where(query)
                .OrderBy(orderBy)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> query)
        {
            return Set
               .Where(query)
               .ToList();
        }

        public IEnumerable<T> Get(int take, int skip)
        {
            return Set
                .OrderBy(e => e.Id)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public void Insert(T item)
        {
            Set.Add(item);
        }

        public void Remove(int id)
        {
            Set.Remove(Set.First(e => e.Id == id));
        }

        public void Remove(T item)
        {
            Set.Remove(item);
        }

        public abstract void Update(int id, T newItem);
    }
}
