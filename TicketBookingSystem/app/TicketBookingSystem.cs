// app/TicketBookingSystem.cs
using bean;
using System;
using System.Collections.Generic;
using TicketBookingSystem.bean;

namespace app
{
    class TicketBookingSystem
    {
        static void Main(string[] args)
        {
            BookingSystemServiceProviderImpl system = new BookingSystemServiceProviderImpl();

            while (true)
            {
                Console.WriteLine("\n======= Ticket Booking Menu =======");
                Console.WriteLine("1. Create Event");
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. Cancel Booking");
                Console.WriteLine("4. Get Available Seats");
                Console.WriteLine("5. View Event Details");
                Console.WriteLine("6. View Booking Details");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Enter event name: "); string name = Console.ReadLine();
                        Console.Write("Enter event date (yyyy-MM-dd): "); DateTime date = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter event time (e.g. 18:30): "); string time = Console.ReadLine();
                        Console.Write("Enter total seats: "); int seats = int.Parse(Console.ReadLine());
                        Console.Write("Enter ticket price: "); decimal price = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter event type (Movie, Concert, Sports): "); string type = Console.ReadLine();
                        Console.Write("Enter venue name: "); string vname = Console.ReadLine();
                        Console.Write("Enter venue address: "); string addr = Console.ReadLine();

                        Venue venue = new Venue(vname, addr);
                        Event ev = system.CreateEvent(name, date, time, seats, price, type, venue);
                        Console.WriteLine("Event created successfully!");
                        break;

                    case "2":
                        Console.Write("Enter event name to book: ");
                        string ename = Console.ReadLine();
                        Console.Write("Enter number of tickets: ");
                        int count = int.Parse(Console.ReadLine());
                        List<Customer> customers = new List<Customer>();

                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"Enter details for Customer {i + 1}:");
                            Console.Write("Name: "); string cname = Console.ReadLine();
                            Console.Write("Email: "); string email = Console.ReadLine();
                            Console.Write("Phone: "); string phone = Console.ReadLine();
                            customers.Add(new Customer(cname, email, phone));
                        }

                        Booking booking = system.BookTickets(ename, count, customers);
                        if (booking != null)
                        {
                            Console.WriteLine("Booking successful!");
                            booking.DisplayBookingDetails();
                        }
                        break;

                    case "3":
                        Console.Write("Enter Booking ID to cancel: ");
                        int bid = int.Parse(Console.ReadLine());
                        system.CancelBooking(bid);
                        break;

                    case "4":
                        Console.WriteLine($"Total Available Tickets: {system.GetAvailableNoOfTickets()}");
                        break;

                    case "5":
                        Console.WriteLine("\nAll Events:");
                        foreach (var e in system.GetEventDetails())
                        {
                            e.DisplayEventDetails();
                        }
                        break;

                    case "6":
                        Console.Write("Enter Booking ID: ");
                        int id = int.Parse(Console.ReadLine());
                        var b = system.GetBookingDetails(id);
                        if (b != null)
                            b.DisplayBookingDetails();
                        else
                            Console.WriteLine("Booking not found!");
                        break;

                    case "7":
                        Console.WriteLine("Exiting... Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
