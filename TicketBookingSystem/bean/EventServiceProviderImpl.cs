// bean/EventServiceProviderImpl.cs
using System;
using System.Collections.Generic;
using bean;
using service;

namespace TicketBookingSystem.bean
{
    public class EventServiceProviderImpl : IEventServiceProvider
    {
        protected List<Event> events = new List<Event>();

        public virtual Event CreateEvent(string eventName, DateTime date, string time, int totalSeats, decimal ticketPrice, string eventType, Venue venue)
        {
            Event ev = null;

            switch (eventType.ToLower())
            {
                case "movie":
                    Console.Write("Enter Genre: "); string genre = Console.ReadLine();
                    Console.Write("Enter Actor Name: "); string actor = Console.ReadLine();
                    Console.Write("Enter Actress Name: "); string actress = Console.ReadLine();
                    ev = new Movie(eventName, date, time, venue, totalSeats, ticketPrice, genre, actor, actress);
                    break;
                case "concert":
                    Console.Write("Enter Artist Name: "); string artist = Console.ReadLine();
                    Console.Write("Enter Type (Theatrical/Classical/Rock): "); string type = Console.ReadLine();
                    ev = new Concert(eventName, date, time, venue, totalSeats, ticketPrice, artist, type);
                    break;
                case "sports":
                    Console.Write("Enter Sport Name: "); string sport = Console.ReadLine();
                    Console.Write("Enter Teams (e.g., India vs Pakistan): "); string teams = Console.ReadLine();
                    ev = new Sports(eventName, date, time, venue, totalSeats, ticketPrice, sport, teams);
                    break;
            }

            if (ev != null) events.Add(ev);
            return ev;
        }

        public List<Event> GetEventDetails() => events;

        public int GetAvailableNoOfTickets()
        {
            int total = 0;
            foreach (var ev in events)
                total += ev.AvailableSeats;
            return total;
        }
    }
}
