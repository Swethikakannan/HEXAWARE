// service/IBookingSystemServiceProvider.cs
using System.Collections.Generic;
using bean;

namespace service
{
    public interface IBookingSystemServiceProvider
    {
        decimal CalculateBookingCost(Event ev, int numTickets);
        Booking BookTickets(string eventName, int numTickets, List<Customer> customers);
        bool CancelBooking(int bookingId);
        Booking GetBookingDetails(int bookingId);
    }
}
