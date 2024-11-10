using System;
using System.Collections.Generic;

namespace FastX_CaseStudy.Models
{
    public partial class bus
    {
        public bus()
        {
            BusOperators = new HashSet<BusOperator>();
            BusRoutes = new HashSet<BusRoute>();
        }

        public int BusId { get; set; }
        public string? BusName { get; set; }
        public string? Bustype { get; set; }
        public string? Amenities { get; set; }
        public int? NumberofSeats { get; set; }
        public int? PricePerSeat { get; set; }

        public virtual ICollection<BusOperator>? BusOperators { get; set; }
        public virtual ICollection<BusRoute>? BusRoutes { get; set; }
    }
}
