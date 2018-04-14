using MrMood.Domain;
using System.Data.Entity;

namespace MrMood.DataAccess.Context
{
    public class MoodContext : DbContext
    {
        public MoodContext(string connString)
            : base(connString)
        {
            
        }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<SongMark> SongMarks { get; set; }

        public DbSet<Tag> Tags { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>()
                .HasMany<Tag>(s => s.Tags)
                .WithMany(t => t.Songs)
                .Map(cs =>
                {
                    cs.MapLeftKey("SongId");
                    cs.MapRightKey("TagId");
                    cs.ToTable("SongTag");
                });
        }
    }
}
