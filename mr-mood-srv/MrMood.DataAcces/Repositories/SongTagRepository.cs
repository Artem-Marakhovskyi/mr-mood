using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MrMood.Domain;

namespace MrMood.DataAccess.Repositories
{
    public class SongTagRepository : ISimpleRepository<SongTag>
    {
        private readonly DbSet<SongTag> _set;

        public SongTagRepository(DbSet<SongTag> set)
        {
            _set = set;
        }

        public IEnumerable<SongTag> Get(Expression<Func<SongTag, bool>> query)
        {
            return _set.Where(query).ToList();
        }

        public void Insert(SongTag item)
        {
            _set.Add(item);
        }

        public void Remove(Expression<Func<SongTag, bool>> query)
        {
            var items = Get(query);

            foreach (var item in items)
            {
                _set.Remove(item);
            }
        }
    }
}
