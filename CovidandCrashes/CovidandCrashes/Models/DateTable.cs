using System;
using System.Collections.Generic;

namespace CovidandCrashes.Models
{
    public partial class DateTable
    {
        public DateTable()
        {
            Covids = new HashSet<Covid>();
            Crashtables = new HashSet<Crashtable>();
        }

        public int DateId { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Covid> Covids { get; set; }
        public virtual ICollection<Crashtable> Crashtables { get; set; }
    }
}
