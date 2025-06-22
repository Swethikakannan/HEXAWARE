// bean/Concert.cs
namespace bean
{
    using System;

    public class Concert : Event
    {
        public string Artist { get; set; }
        public string Type { get; set; }

        public Concert() { }

        public Concert(string eventName, DateTime eventDate, string eventTime, Venue venue, int totalSeats, decimal ticketPrice, string artist, string type)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Concert")
        {
            Artist = artist;
            Type = type;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine("\n🎤 Concert Event");
            base.DisplayEventDetails();
            Console.WriteLine($"Artist: {Artist}, Type: {Type}");
        }
    }
}
