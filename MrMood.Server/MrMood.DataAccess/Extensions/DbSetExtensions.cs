using System.Data.Entity;

namespace MrMood.DataAccess.Extensions
{
    public static class DbSetExtensions
    {
        public static void AddRange<T>(this DbSet<T> me, params T[] ts) where T : class
        {
            foreach (var t in ts)
            {
                me.Add(t);
            }
        }
    }
}
