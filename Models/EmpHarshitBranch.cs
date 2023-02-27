﻿using System;
using System.Collections.Generic;

namespace fms.Models
{
    public partial class EmpHarshitBranch
    {
        public int Id { get; set; }
        public string Ename { get; set; }
        public string BranchName { get; set; }
        public int? EmpId { get; set; }

        public virtual Empharshit Emp { get; set; }
    }
}
