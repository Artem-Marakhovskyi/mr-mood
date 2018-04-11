using Microsoft.EntityFrameworkCore;
using MrMood.Domain;

namespace MrMood.DataAccess.Context
{
    public class MoodContext : DbContext
    {
        public MoodContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<SongMark> SongMarks { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
