using Microsoft.EntityFrameworkCore;
using MrMood.Domain;
using System.Linq;

namespace MrMood.DataAccess.Repositories
{
    public class SongRepository : Repository<Song>
    {
        public SongRepository(DbSet<Song> set) : base(set)
        {

        }

        public override void Update(int id, Song newItem)
        {
            var song = Set.First(e => e.Id == id);

            song.Title = newItem.Title;
            song.FileName = newItem.FileName;
            song.Duration = newItem.Duration;
        }
    }

}
