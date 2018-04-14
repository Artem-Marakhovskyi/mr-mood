using MrMood.Domain;
using System.Data.Entity;
using System.Linq;

namespace MrMood.DataAccess.Repositories
{
    public class ArtistRepository : Repository<Artist>
    {
        public ArtistRepository(DbSet<Artist> set) : base(set)
        {

        }

        public override void Update(int id, Artist newItem)
        {
            var artist = Set.First(e => e.Id == id);

            artist.Title = newItem.Title;
            artist.Description = newItem.Description;
        }
    }
}
