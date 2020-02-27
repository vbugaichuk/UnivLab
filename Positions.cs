using System;
using System.Collections.Generic;

namespace IT_Companies
{
    public partial class Positions
    {
        public Positions()
        {
            EmpSubs = new HashSet<EmpSubs>();
        }

        public int Id { get; set; }
        public string Position { get; set; }

        public virtual ICollection<EmpSubs> EmpSubs { get; set; }
    }
}
