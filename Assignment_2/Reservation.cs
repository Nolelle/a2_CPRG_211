namespace Assignment_2
{
    public enum ReservationStatus
    {
        Active,
        Inactive
    }
    internal class Reservation
    {
        public string? ReservationCode { get; set; }
        public string? FlightCode { get; set; }
        public string? Airline { get; set; }
        public double Cost { get; set; }
        public string? Citizenship { get; set; }
        public ReservationStatus Status { get; set; }
        public string? FullName { get; set; }

        public Reservation(string? reservationCode, string? flightCode, string? airline, double cost, string? citizenship, ReservationStatus status, string? fullName)
        {
            ReservationCode = reservationCode;
            FlightCode = flightCode;
            Airline = airline;
            Cost = cost;
            Citizenship = citizenship;
            Status = status;
            FullName = fullName;
        }

    }
}
