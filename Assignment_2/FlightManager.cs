namespace Assignment_2
{
    internal class FlightManager
    {
        private List<Flight> _flights = new List<Flight>();
        public void AddFlight(Flight flight)
        {
            _flights.Add(flight);
        }

        public List<Flight> FindFlights(string origin, string destination, string day)
        {
            var matchingFlights = _flights.Where(flight =>
                flight.Origin.Equals(origin, StringComparison.OrdinalIgnoreCase) &&
                flight.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase) &&
                flight.departureDay.Equals(day, StringComparison.OrdinalIgnoreCase)).ToList();

            return matchingFlights;
        }

    }
}
