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

        public DbSet<SongTag> SongTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongTag>()
                .HasKey(t => new { t.SongId, t.TagId });

            modelBuilder.Entity<SongTag>()
                .HasOne(sc => sc.Tag)
                .WithMany(s => s.SongTags)
                .HasForeignKey(sc => sc.TagId);

            modelBuilder.Entity<SongTag>()
                .HasOne(sc => sc.Song)
                .WithMany(c => c.SongTags)
                .HasForeignKey(sc => sc.SongId);
        }
    }
}
