namespace MrMood.Domain
{
    public class SongTag
    {
        public int SongId { get; set; }

        public int TagId { get; set; }

        public Song Song { get; set; }

        public Tag Tag { get; set; }
    }
}
