// bean/Sports.cs
namespace bean
{
    using System;

    public class Sports : Event
    {
        public string SportName { get; set; }
        public string TeamsName { get; set; }

        public Sports() { }

        public Sports(string eventName, DateTime eventDate, string eventTime, Venue venue, int totalSeats, decimal ticketPrice, string sportName, string teamsName)
            : base(eventName, eventDate, eventTime, venue, totalSeats, ticketPrice, "Sports")
        {
            SportName = sportName;
            TeamsName = teamsName;
        }

        public override void DisplayEventDetails()
        {
            Console.WriteLine("\n🏟️ Sports Event");
            base.DisplayEventDetails();
            Console.WriteLine($"Sport: {SportName}, Teams: {TeamsName}");
        }
    }
}

