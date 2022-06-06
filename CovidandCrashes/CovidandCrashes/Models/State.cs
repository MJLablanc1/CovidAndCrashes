using System;
using System.Collections.Generic;

namespace CovidandCrashes.Models
{
    public partial class State
    {
        public State()
        {
            Covids = new HashSet<Covid>();
            Crashtables = new HashSet<Crashtable>();
        }

        public int StateId { get; set; }
        public string? State1 { get; set; }

        public virtual ICollection<Covid> Covids { get; set; }
        public virtual ICollection<Crashtable> Crashtables { get; set; }
    }
}
