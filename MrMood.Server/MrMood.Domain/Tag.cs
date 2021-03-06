﻿using System.Collections.Generic;

namespace MrMood.Domain
{
    public class Tag : Entity
    {
        public string Title { get; set; }

        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
