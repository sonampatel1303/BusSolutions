using System;
using System.Collections.Generic;

namespace FastX_CaseStudy.Models
{
    public partial class BusRoute
    {
        public BusRoute()
        {
            Bookings = new HashSet<Booking>();
        }

        public int RouteId { get; set; }
        public string? SourcePoint { get; set; }
        public string? Destination { get; set; }
        public int? BusId { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }

        public virtual bus? Bus { get; set; }
        public virtual ICollection<Booking>? Bookings { get; set; }
    }
}
