namespace FMS_Front_End.Models
{
    public class CheckIn
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public DateTime CheckInTime { get; set; }
        public string SeatNumber { get; set; }
        public bool IsBoarded { get; set; }
    }
}
