namespace Assignment_2
{
    internal class Flight
    {
        public string? FlightCode { get; set; }
        public string? Airline { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public string? DepartureTime { get; set; }
        public string? ArrivalTime { get; set; }
        public string? Price { get; set; }
        public string? Day { get; set; }

        public Flight(string? flightCode, string? airline, string? origin, string? destination, string? departureTime, string? arrivalTime, string? price, string? day)
        {
            FlightCode = flightCode;
            Airline = airline;
            Origin = origin;
            Destination = destination;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Price = price;
            Day = day;
        }
    }
}
