using System;
using System.Collections.Generic;

namespace FastX_CaseStudy.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Payments = new HashSet<Payment>();
        }

        public int BookingId { get; set; }
        public int? UserId { get; set; }
        public int? RouteId { get; set; }
        public int? NumberofSeats { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? BookingDate { get; set; }
        public string? BookingStatus { get; set; }

        public virtual BusRoute? Route { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}
