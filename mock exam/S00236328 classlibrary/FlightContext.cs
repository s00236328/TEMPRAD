﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S00236328_classlibrary
{
    public class FlightContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<PassengerBooking> PassengerBookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\repo\\TEMPRAD\\mock exam\\s00236328 consoleapp\\flights.db");
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  modelBuilder.Entity<PassengerBooking>()
          //.HasOne(pb => pb.Flight)
          //.WithMany() // One Flight can have many PassengerBookings
          //.HasForeignKey(pb => pb.FlightId);

          //  modelBuilder.Entity<PassengerBooking>()
          //      .HasOne(pb => pb.Passenger)
          //      .WithMany() // One Passenger can have many bookings
          //      .HasForeignKey(pb => pb.PassengerId);

            base.OnModelCreating(modelBuilder);
            // Seed data for Flights
            modelBuilder.Entity<Flight>().HasData(
                new Flight { FlightId = 1, FlightNo = "IT-001", DepartureTime = new DateTime(2025, 1, 12, 22, 0, 0), Origin = "Dublin", Destination = "Rome", DestinationCountry = "Italy", MaxSeats = 110 },
                new Flight { FlightId = 2, FlightNo = "EN-002", DepartureTime = new DateTime(2025, 1, 12, 22, 0, 0), Origin = "Dublin", Destination = "London", DestinationCountry = "England", MaxSeats = 110 },
                new Flight { FlightId = 3, FlightNo = "FR-001", DepartureTime = new DateTime(2025, 1, 12, 22, 0, 0), Origin = "Dublin", Destination = "Paris", DestinationCountry = "France", MaxSeats = 120 },
                new Flight { FlightId = 4, FlightNo = "BE-001", DepartureTime = new DateTime(2025, 1, 12, 22, 0, 0), Origin = "Dublin", Destination = "Brussels", DestinationCountry = "Belgium", MaxSeats = 88 },
                new Flight { FlightId = 5, FlightNo = "DU-001", DepartureTime = new DateTime(2025, 1, 12, 22, 0, 0), Origin = "London", Destination = "Dublin", DestinationCountry = "Ireland", MaxSeats = 110 }
            );

            // Seed data for Passengers
            modelBuilder.Entity<Passenger>().HasData(
                new Passenger { PassengerId = 1, PassengerName = "Fred Farnell", Passport = "P010203" },
                new Passenger { PassengerId = 2, PassengerName = "Tom McManus", Passport = "P896745" },
                new Passenger { PassengerId = 3, PassengerName = "Bill Trimble", Passport = "P231425" },
                new Passenger { PassengerId = 4, PassengerName = "Freda McDonald", Passport = "P235678" },
                new Passenger { PassengerId = 5, PassengerName = "Mary Malone", Passport = "P214587" },
                new Passenger { PassengerId = 6, PassengerName = "Tom McManus", Passport = "P893482" }
            );

            // Seed data for PassengerBookings
            modelBuilder.Entity<PassengerBooking>().HasData(
                new PassengerBooking { Id = 1, FlightId = 2, PassengerId = 1, TicketType = TicketType.Economy, TicketCost = 51.83, BaggageCharge = 30 },
                new PassengerBooking { Id = 2, FlightId = 2, PassengerId = 2, TicketType = TicketType.FirstClass, TicketCost = 127.00, BaggageCharge = 10 },
                new PassengerBooking { Id = 3, FlightId = 3, PassengerId = 3, TicketType = TicketType.FirstClass, TicketCost = 140.00, BaggageCharge = 10 },
                new PassengerBooking { Id = 4, FlightId = 4, PassengerId = 4, TicketType = TicketType.Economy, TicketCost = 50.00, BaggageCharge = 15 },
                new PassengerBooking { Id = 5, FlightId = 1, PassengerId = 5, TicketType = TicketType.Economy, TicketCost = 69.00, BaggageCharge = 15 },
                new PassengerBooking { Id = 6, FlightId = 5, PassengerId = 6, TicketType = TicketType.FirstClass, TicketCost = 127.00, BaggageCharge = 10 }
            );
         
        }
    }
}
