using System;
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

        public int Energy { get; set; }

        public int Tempo { get; set; }
    }
}
