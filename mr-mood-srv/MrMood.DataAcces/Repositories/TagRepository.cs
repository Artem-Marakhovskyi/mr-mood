using Microsoft.EntityFrameworkCore;
using MrMood.Domain;
using System.Linq;

namespace MrMood.DataAccess.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(DbSet<Tag> set) : base(set)
        {

        }

        public override void Update(int id, Tag newItem)
        {
            var tag = Set.First(e => e.Id == id);

            tag.Title = newItem.Title;
        }
    }
}
