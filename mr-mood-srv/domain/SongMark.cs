namespace MrMood.Domain
{
    public class SongMark : Entity
    {
        public int Energy { get; set; }

        public int Tempo { get; set; }

        public Song Song { get; set; }
    }
}
