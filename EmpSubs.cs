using System;
using System.Collections.Generic;

namespace IT_Companies
{
    public partial class EmpSubs
    {
        public int Id { get; set; }
        public float Salary { get; set; }
        public int PositionId { get; set; }
        public int SubdivisionId { get; set; }
        public int EmployerId { get; set; }

        public virtual Employers Employer { get; set; }
        public virtual Positions Position { get; set; }
        public virtual Subdivisions Subdivision { get; set; }
    }
}
