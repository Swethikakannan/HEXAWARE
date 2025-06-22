// bean/Booking.cs
namespace bean
{
    using System;
    using System.Collections.Generic;

    public class Booking
    {
        private static int bookingCounter = 1000;

        public int BookingId { get; private set; }
        public List<Customer> Customers { get; set; }
        public Event Event { get; set; }
        public int NumTickets { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime BookingDate { get; set; }

        public Booking()
        {
            BookingId = bookingCounter++;
            BookingDate = DateTime.Now;
        }

        public Booking(Event ev, int numTickets, List<Customer> customers)
        {
            BookingId = bookingCounter++;
            Event = ev;
            NumTickets = numTickets;
            Customers = customers;
            BookingDate = DateTime.Now;
            TotalCost = ev.TicketPrice * numTickets;
        }

        public void DisplayBookingDetails()
        {
            Console.WriteLine($"\n📄 Booking ID: {BookingId}, Date: {BookingDate:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"Event: {Event.EventName}, Tickets: {NumTickets}, Total Cost: {TotalCost:C}");
            Console.WriteLine("-- Customer List --");
            foreach (var c in Customers)
            {
                c.DisplayCustomerDetails();
            }
        }
    }
}


