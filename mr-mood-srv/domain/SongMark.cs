using System;
namespace MrMood.Domain
{
    public class SongMark
    {
        public int Id { get; set; }

        public int Energy { get; set; }

        public int Tempo { get; set; }

        public Song Song { get; set; }
    }
}
