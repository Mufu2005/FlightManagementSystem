namespace FMS_Front_End.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string PassengerName { get; set; }
        public string SeatNumber { get; set; }
    }
}
