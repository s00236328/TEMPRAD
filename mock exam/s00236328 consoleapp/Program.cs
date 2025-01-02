using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using S00236328_classlibrary;

namespace s00236328_consoleapp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ListFlightRevenue();
            ListPassengers(2);
        }

        static void ListFlightRevenue()
        {
            using (var context = new FlightContext())
            {
                // LINQ query to calculate revenue for each flight
                var flightRevenues = context.Flights
                    .Select(f => new
                    {
                        FlightNumber = f.FlightNo,
                        Destination = f.Destination,
                        DepartureDate = f.DepartureTime,
                        TotalRevenue = context.PassengerBookings
                            .Where(pb => pb.FlightId == f.FlightId)
                            .Sum(pb => pb.TicketCost + pb.BaggageCharge)
                    })
                    .ToList();

                // Print out the flight details and revenue
                Console.WriteLine("Flight Revenue Report:");
                Console.WriteLine("-----------------------");
                foreach (var flight in flightRevenues)
                {
                    Console.WriteLine($"Flight No: {flight.FlightNumber}");
                    Console.WriteLine($"Destination: {flight.Destination}");
                    Console.WriteLine($"Departure Date: {flight.DepartureDate}");
                    Console.WriteLine($"Total Revenue: €{flight.TotalRevenue:F2}");
                    Console.WriteLine();
                }
            }
        }

        static void ListPassengers(int flightId)
        {
            using (var context = new FlightContext())
            {
                var passengers = context.PassengerBookings
                    .Include(pb => pb.Flight)
                    .Include(pb => pb.Passenger)
                    .Where(pb => pb.FlightId == flightId)
                    .Select(pb => new
                    {
                        PassengerName = pb.Passenger.PassengerName,
                        TicketType = pb.TicketType.ToString(),
                        Destination = pb.Flight.Destination
                    })
                    .ToList();

                if (passengers.Any())
                {
                    Console.WriteLine($"Passengers for Flight ID {flightId}:");
                    foreach (var passenger in passengers)
                    {
                        Console.WriteLine($"Name: {passenger.PassengerName}, Ticket Type: {passenger.TicketType}, Destination: {passenger.Destination}");
                    }
                }
                else
                {
                    Console.WriteLine($"No passengers found for Flight ID {flightId}.");
                }
            }
        }
    }
}
