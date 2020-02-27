using System;
using System.Collections.Generic;

namespace IT_Companies
{
    public partial class ItCompanies
    {
        public ItCompanies()
        {
            Offices = new HashSet<Offices>();
            Products = new HashSet<Products>();
        }

        public string Name { get; set; }
        public int Year { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Offices> Offices { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
