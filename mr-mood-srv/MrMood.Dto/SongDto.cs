using System.Collections.Generic;

namespace MrMood.Dto
{
    public class SongDto
    { 
        public int Id { get; set; }

        public string SongTitle { get; set; }

        public string ArtistTitle { get; set; }

        public int Duration { get; set; }

        public string FileName { get; set; }

        public IEnumerable<string> Tags { get; set; } = new List<string>();

        public double MeanTempo { get; set; }

        public double MeanEnergy { get; set; }

        public IEnumerable<SongMarkDto> SongMarks { get; set; }
    }
}
