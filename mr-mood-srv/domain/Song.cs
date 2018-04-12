using System.Collections.Generic;

namespace MrMood.Domain
{
    public class Song : Entity
    {
        public int ArtistId { get; set; }

        public string Title { get; set; }

        public double MeanEnergy { get; set; }

        public double MeanTempo { get; set; }

        public int Duration { get; set; }

        public string FileName { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual List<SongMark> SongMarks { get; set; } = new List<SongMark>();

        public virtual List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
