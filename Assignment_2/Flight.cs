namespace Assignment_2
{
    internal class Flight
    {
        public string FlightCode { get; set; }
        public string Airline { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public string DepartureDay { get; set; }
        public int SeatsAvailable { get; set; }

        public Flight(string flightCode, string airline, string origin, string destination, string departureTime, string arrivalTime, decimal price, string departureDay, int seatsAvailable)
        {
            FlightCode = flightCode;
            Airline = airline;
            Origin = origin;
            Destination = destination;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Price = price;
            DepartureDay = departureDay;
            SeatsAvailable = seatsAvailable;
        }

        public bool TryBookSeat()
        {
            if (SeatsAvailable > 0)
            {
                SeatsAvailable--;
                return true;
            }
            return false;
        }
    }
}
