// bean/Movie.cs
namespace bean
{
    using System;

    public class Movie : Event
    {
        public string Genre { get; set; }
        public string ActorName { get; set; }
        public string ActressName { get; set; }

        public Movie() { }

        public Movie(string eventName, DateTime eventDate, string eventTime, Venue venue, int totalSeats, decimal ticketPrice, string genre, string actor, string actress)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Movie")
        {
            Genre = genre;
            ActorName = actor;
            ActressName = actress;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine("\n🎬 Movie Event");
            base.DisplayEventDetails();
            Console.WriteLine($"Genre: {Genre}, Actor: {ActorName}, Actress: {ActressName}");
        }
    }
}

