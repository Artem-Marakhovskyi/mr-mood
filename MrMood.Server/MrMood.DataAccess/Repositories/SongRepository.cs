using MrMood.Domain;
using System.Data.Entity;
using System.Linq;

namespace MrMood.DataAccess.Repositories
{
    public class SongRepository : Repository<Song>
    {
        public SongRepository(DbSet<Song> set) 
            : base(set,
                  set.Include(e => e.Artist).Include(e => e.SongMarks).Include(e => e.Tags))
        {
            
        }

        public override void Update(int id, Song newItem)
        {
            var song = Set.Where(e => e.Id == id).First();

            song.Title = newItem.Title;
            song.FileName = newItem.FileName;
            song.Duration = newItem.Duration;
            song.MeanTempo = newItem.MeanTempo;
            song.MeanEnergy = newItem.MeanEnergy;
            
            
        }
    }

}
