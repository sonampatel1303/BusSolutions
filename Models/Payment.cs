using System;
using System.Collections.Generic;

namespace FastX_CaseStudy.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int? BookingId { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string? PaymentMode { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? Status { get; set; }

        public virtual Booking? Booking { get; set; }
    }
}
