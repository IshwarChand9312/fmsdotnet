﻿using System;
using System.Collections.Generic;

namespace fms.Models
{
    public partial class Empishan
    {
        public int Eid { get; set; }
        public string Ename { get; set; }
        public int? Salary { get; set; }
        public DateTime? Doj { get; set; }
        public string City { get; set; }
    }
}