using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MrMood.Domain;
using System.Linq;

namespace MrMood.DataAccess.Repositories
{
    public class SongRepository : Repository<Song>
    {
        public SongRepository(DbSet<Song> set) 
            : base(set,
                  set.Include(e => e.Artist).Include(e => e.SongMarks).Include(e => e.SongTags))
        {
            
        }

        public override void Update(int id, Song newItem)
        {
            var song = Set.First(e => e.Id == id);

            song.Title = newItem.Title;
            song.FileName = newItem.FileName;
            song.Duration = newItem.Duration;
            song.MeanTempo = newItem.MeanTempo;
            song.MeanEnergy = newItem.MeanEnergy;
        }
    }

}
