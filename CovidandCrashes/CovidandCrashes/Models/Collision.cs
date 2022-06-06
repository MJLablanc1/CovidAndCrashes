using System;
using System.Collections.Generic;

namespace CovidandCrashes.Models
{
    public partial class Collision
    {
        public Collision()
        {
            Crashtables = new HashSet<Crashtable>();
        }

        public int CollisionId { get; set; }
        public string? Collision1 { get; set; }

        public virtual ICollection<Crashtable> Crashtables { get; set; }
    }
}
