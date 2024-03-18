namespace Assignment_2.Data
{
    public enum ReservationStatus
    {
        Active,
        Inactive
    }

    [Serializable]
    internal class Reservation
    {
        public string FlightCode { get; set; }
        public string Airline { get; set; }
        public DayOfWeek DepartureDay { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public int Cost { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Citizenship { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Active;
        public string ReservationCode { get; set; }

        public Reservation(string airline, DayOfWeek departureDay, TimeSpan departureTime, int cost, string firstName, string lastName, string citizenship, string reservationCode, ReservationStatus status = ReservationStatus.Active)
        {
            Airline = airline;
            DepartureDay = departureDay;
            DepartureTime = departureTime;
            Cost = cost;
            FirstName = firstName;
            LastName = lastName;
            Citizenship = citizenship;
            ReservationCode = reservationCode;
            Status = status;
        }

        public override string ToString()
        {
            return $"Reservation Code: {ReservationCode}, Airline: {Airline}, " +
                   $"Departure: {DepartureDay} at {DepartureTime}, " +
                   $"Cost: {Cost:C}, Citizenship: {Citizenship}, Status: {Status}, " +
                   $"Full Name: {FirstName} {LastName}";
        }

    }

}
