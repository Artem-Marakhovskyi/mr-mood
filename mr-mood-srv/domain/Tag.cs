using System;
using System.Collections.Generic;

namespace MrMood.Domain
{
    public class Tag
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual IEnumerable<Song> Songs { get; set; } = new List<Song>();
    }
}
