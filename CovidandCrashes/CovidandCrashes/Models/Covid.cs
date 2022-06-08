using System;
using System.Collections.Generic;

namespace CovidandCrashes.Models
{
    public partial class Covid
    {
        public int CovidId { get; set; }
        public int StateId { get; set; }
        public int Hospitalization { get; set; }
        public int Deaths { get; set; }
        public int DateId { get; set; }

        public virtual DateTable Date { get; set; } = null!;
        public virtual State State { get; set; } = null!;
    }
}
