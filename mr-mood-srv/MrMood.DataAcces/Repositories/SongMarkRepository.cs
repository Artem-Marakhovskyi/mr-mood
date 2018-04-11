using Microsoft.EntityFrameworkCore;
using MrMood.Domain;
using System.Linq;

namespace MrMood.DataAccess.Repositories
{
    public class SongMarkRepository : Repository<SongMark>
    {
        public SongMarkRepository(DbSet<SongMark> set) : base(set)
        {

        }

        public override void Update(int id, SongMark newItem)
        {
            var songMark = Set.First(e => e.Id == id);

            songMark.Energy = newItem.Energy;
            songMark.Tempo = newItem.Energy;
        }
    }
}
