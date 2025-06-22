// bean/Event.cs
namespace bean
{
    using System;

    public abstract class Event
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventTime { get; set; }
        public Venue Venue { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public string EventType { get; set; }

        public Event() { }

        public Event(string eventName, DateTime eventDate, string eventTime, Venue venue, int totalSeats, decimal ticketPrice, string eventType)
        {
            EventName = eventName;
            EventDate = eventDate;
            EventTime = eventTime;
            Venue = venue;
            TotalSeats = totalSeats;
            AvailableSeats = totalSeats;
            TicketPrice = ticketPrice;
            EventType = eventType;
        }

        public decimal CalculateTotalRevenue()
        {
            int sold = TotalSeats - AvailableSeats;
            return sold * TicketPrice;
        }

        public int GetBookedNoOfTickets() => TotalSeats - AvailableSeats;

        public bool BookTickets(int numTickets)
        {
            if (numTickets <= AvailableSeats)
            {
                AvailableSeats -= numTickets;
                return true;
            }
            return false;
        }

        public void CancelBooking(int numTickets)
        {
            AvailableSeats += numTickets;
            if (AvailableSeats > TotalSeats)
                AvailableSeats = TotalSeats;
        }

        public virtual void DisplayEventDetails()
        {
            Console.WriteLine($"Event: {EventName}, Date: {EventDate:yyyy-MM-dd}, Time: {EventTime}, Type: {EventType}, Seats Available: {AvailableSeats}/{TotalSeats}, Price: {TicketPrice:C}");
            Venue.DisplayVenueDetails();
        }
    }
}
