using System;
using System.Collections.Generic;

namespace fms.Models
{
    public partial class Customer
    {
        public Customer()
        {
            TransactionVrms = new HashSet<TransactionVrm>();
        }

        public int Userid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<TransactionVrm> TransactionVrms { get; set; }
    }
}
