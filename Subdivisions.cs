using System;
using System.Collections.Generic;

namespace IT_Companies
{
    public partial class Subdivisions
    {
        public Subdivisions()
        {
            EmpSubs = new HashSet<EmpSubs>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OfficeId { get; set; }

        public virtual Offices Office { get; set; }
        public virtual ICollection<EmpSubs> EmpSubs { get; set; }
    }
}
