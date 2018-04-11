using System.Collections.Generic;

namespace MrMood.Domain
{
    public class Tag : Entity
    {
        public string Title { get; set; }

        public virtual IEnumerable<Song> Songs { get; set; } = new List<Song>();
    }
}
