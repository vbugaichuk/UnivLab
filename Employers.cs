using System;
using System.Collections.Generic;

namespace IT_Companies
{
    public partial class Employers
    {
        public Employers()
        {
            EmpSubs = new HashSet<EmpSubs>();
        }

        public string Name { get; set; }
        public string Passport { get; set; }
        public int Year { get; set; }
        public int Id { get; set; }
        public string Education { get; set; }

        public virtual ICollection<EmpSubs> EmpSubs { get; set; }
    }
}
