using System;
using System.Collections.Generic;

namespace fms.Models
{
    public partial class Team
    {
        public Team()
        {
            Emps = new HashSet<Emp>();
        }

        public int? Id { get; set; }
        public string TeamName { get; set; }
        public string TeamLead { get; set; }

        public virtual ICollection<Emp> Emps { get; set; }
    }
}
