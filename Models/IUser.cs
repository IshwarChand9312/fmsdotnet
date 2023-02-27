using System;
using System.Collections.Generic;

namespace fms.Models
{
    public partial class IUser
    {
        public IUser()
        {
            IBookings = new HashSet<IBooking>();
        }

        public int UserId { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }

        public virtual ICollection<IBooking> IBookings { get; set; }
    }
}
