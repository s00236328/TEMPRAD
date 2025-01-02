using System.ComponentModel.DataAnnotations;

namespace S00236328_classlibrary
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string FlightNo { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string DestinationCountry { get; set; }
        public int MaxSeats { get; set; }

        // Navigation property
        public ICollection<PassengerBooking> PassengerBookings { get; set; }
    }

    public class Passenger
    {
        public int PassengerId { get; set; }
        [Required]
        public string PassengerName { get; set; }
        [Required, StringLength(7, ErrorMessage = "Passport number must not exceed 7 characters.")]
        public string Passport { get; set; }

        // Navigation property
        public ICollection<PassengerBooking> PassengerBookings { get; set; }
    }

    public class PassengerBooking
    {
        public int Id { get; set; } // Primary Key

        // Foreign keys
        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }

        public int PassengerId { get; set; }
        public virtual Passenger Passenger { get; set; }
        [Range(5.01, int.MaxValue)]
        public double TicketCost { get; set; }
        public TicketType TicketType { get; set; }
        public int BaggageCharge { get; set; }
    }

    public enum TicketType
    {
        Economy,
        FirstClass
    }
}
