using MrMood.Domain;
using System.Data.Entity;
using System.Linq;

namespace MrMood.DataAccess.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(DbSet<Tag> set) : base(set, set.Include(e => e.Songs))
        {

        }

        public override void Update(int id, Tag newItem)
        {
            var tag = Set.First(e => e.Id == id);

            tag.Title = newItem.Title;
        }
    }
}
