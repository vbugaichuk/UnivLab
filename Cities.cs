using System;
using System.Collections.Generic;

namespace IT_Companies
{
    public partial class Cities
    {
        public Cities()
        {
            Offices = new HashSet<Offices>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<Offices> Offices { get; set; }
    }
}
