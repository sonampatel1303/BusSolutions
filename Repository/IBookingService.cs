using FastX_CaseStudy.Models;

namespace FastX_CaseStudy.Repository
{
    public interface IBookingService
    {
        List<Booking> GetallBookings();
        List<Booking> ViewBookingHistorybyId(int id);
        int AddBooking(Booking booking);

        string UpdateBooking(Booking booking);
        string CancelBooking(int id);
        string DeleteBooking(int id);
    }
}
