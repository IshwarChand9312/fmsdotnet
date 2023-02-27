using System;
using System.Collections.Generic;

namespace fms.Models
{
    public partial class TransactionVrm
    {
        public int TransactionId { get; set; }
        public int VehicleId { get; set; }
        public int Userid { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public decimal RentalRate { get; set; }

        public virtual Customer User { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
