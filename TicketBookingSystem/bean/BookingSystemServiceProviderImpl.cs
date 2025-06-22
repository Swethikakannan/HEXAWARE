// bean/BookingSystemServiceProviderImpl.cs
using service;
using System;
using System.Collections.Generic;
using TicketBookingSystem.bean;

namespace bean
{
    public class BookingSystemServiceProviderImpl : EventServiceProviderImpl, IBookingSystemServiceProvider
    {
        private List<Booking> bookings = new List<Booking>();

        public decimal CalculateBookingCost(Event ev, int numTickets)
        {
            return ev.TicketPrice * numTickets;
        }

        public Booking BookTickets(string eventName, int numTickets, List<Customer> customers)
        {
            Event ev = events.Find(e => e.EventName.Equals(eventName, StringComparison.OrdinalIgnoreCase));
            if (ev == null)
            {
                Console.WriteLine("Event not found!");
                return null;
            }

            if (!ev.BookTickets(numTickets))
            {
                Console.WriteLine("Not enough seats available!");
                return null;
            }

            var booking = new Booking(ev, numTickets, customers);
            bookings.Add(booking);
            return booking;
        }

        public bool CancelBooking(int bookingId)
        {
            Booking booking = bookings.Find(b => b.BookingId == bookingId);
            if (booking == null)
            {
                Console.WriteLine("Booking not found!");
                return false;
            }
            booking.Event.CancelBooking(booking.NumTickets);
            bookings.Remove(booking);
            Console.WriteLine("Booking cancelled successfully.");
            return true;
        }

        public Booking GetBookingDetails(int bookingId)
        {
            return bookings.Find(b => b.BookingId == bookingId);
        }
    }
}
