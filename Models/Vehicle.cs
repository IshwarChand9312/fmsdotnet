using System;
using System.Collections.Generic;

namespace fms.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            TransactionVrms = new HashSet<TransactionVrm>();
        }

        public int VehicleId { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public string VehicleType { get; set; }
        public int DailyRent { get; set; }
        public int IsAvailable { get; set; }
        public int KmsTravelled { get; set; }

        public virtual ICollection<TransactionVrm> TransactionVrms { get; set; }
    }
}
