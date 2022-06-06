using System;
using System.Collections.Generic;

namespace CovidandCrashes.Models
{
    public partial class Intersection
    {
        public Intersection()
        {
            Crashtables = new HashSet<Crashtable>();
        }

        public int IntersectionId { get; set; }
        public string? Intersection1 { get; set; }

        public virtual ICollection<Crashtable> Crashtables { get; set; }
    }
}
