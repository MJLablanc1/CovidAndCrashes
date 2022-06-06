using System;
using System.Collections.Generic;

namespace CovidandCrashes.Models
{
    public partial class Crashtable
    {
        public int CrashId { get; set; }
        public int? DateId { get; set; }
        public int? StateId { get; set; }
        public int? CollisionId { get; set; }
        public int? IntersectionId { get; set; }
        public int? Deaths { get; set; }

        public virtual Collision? Collision { get; set; }
        public virtual DateTable? Date { get; set; }
        public virtual Intersection? Intersection { get; set; }
        public virtual State? State { get; set; }
    }
}
