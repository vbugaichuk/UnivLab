using System;
using System.Collections.Generic;

namespace IT_Companies
{
    public partial class Products
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Budget { get; set; }
        public int ItCompanyId { get; set; }
        public int Id { get; set; }

        public virtual ItCompanies ItCompany { get; set; }
    }
}
