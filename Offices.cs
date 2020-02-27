using System;
using System.Collections.Generic;

namespace IT_Companies
{
    public partial class Offices
    {
        public Offices()
        {
            Subdivisions = new HashSet<Subdivisions>();
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public float Square { get; set; }
        public string Address { get; set; }
        public int ItCompanyId { get; set; }

        public virtual Cities City { get; set; }
        public virtual ItCompanies ItCompany { get; set; }
        public virtual ICollection<Subdivisions> Subdivisions { get; set; }
    }
}
