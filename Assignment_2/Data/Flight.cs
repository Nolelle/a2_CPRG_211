namespace Assignment_2.Data
{
    public enum DayOfWeek
    {
        Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
    }

    [Serializable]
    internal class Flight
    {
        public string FlightCode { get; set; }
        public string Airline { get; set; }
        public string OriginAirport { get; set; }
        public string DestinationAirport { get; set; }
        public TimeSpan Time { get; set; }
        public int Price { get; set; }
        public double Distance { get; set; }
        public DayOfWeek Day { get; set; }

        public Flight(string flightCode, string airline, string origin, string destination, DayOfWeek day, TimeSpan time, int price, double distance)
        {
            FlightCode = flightCode;
            Airline = airline;
            OriginAirport = origin;
            DestinationAirport = destination;
            Time = time;
            Price = price;
            Distance = distance;
            Day = day;
        }

        public override string ToString()
        {
            return $"FlightCode: {FlightCode}, Airline: {Airline}, Origin Airport: {OriginAirport}, Destination Airport: {DestinationAirport}, " +
                   $"ArrivalTime: {Time}, Price: {Price:C}, ArrivalDay: {Day}. ";
        }
    }
}
