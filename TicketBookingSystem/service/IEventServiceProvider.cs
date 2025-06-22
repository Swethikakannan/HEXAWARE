// service/IEventServiceProvider.cs
using System;
using System.Collections.Generic;
using bean;

namespace service
{
    public interface IEventServiceProvider
    {
        Event CreateEvent(string eventName, DateTime date, string time, int totalSeats, decimal ticketPrice, string eventType, Venue venue);
        List<Event> GetEventDetails();
        int GetAvailableNoOfTickets();
    }
}
