namespace BookingService.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int FlightId { get; set; }        // Foreign Key reference
        public string PassengerName { get; set; }
        public string SeatNumber { get; set; }
    }
}
