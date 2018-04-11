using System.Collections.Generic;

namespace MrMood.Domain
{
    public class Song : Entity
    {
        public int ArtistId { get; set; }

        public string Title { get; set; }

        public int Duration { get; set; }

        public string FileName { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual IEnumerable<SongMark> SongMarks { get; set; } = new List<SongMark>();

        public virtual IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
    }
}
