using System;
using System.Collections.Generic;

namespace fms.Models
{
    public partial class Flightawa
    {
        public string Uid { get; set; }
        public string Uname { get; set; }
        public string JFrom { get; set; }
        public string JTo { get; set; }
        public DateTime? Doj { get; set; }
        public string Cid { get; set; }

        public virtual Companyawa CidNavigation { get; set; }
    }
}
