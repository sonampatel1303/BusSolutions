using System;
using System.Collections.Generic;

namespace FastX_CaseStudy.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Role { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<Booking>? Bookings { get; set; }
    }
}
