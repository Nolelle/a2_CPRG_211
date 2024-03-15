namespace Assignment_2
{
    internal class FlightManager
    {
        private List<Flight> _flights = new List<Flight>();

        public List<Flight> FindFlights(string origin, string destination, string day)
        {
            // Example implementation: filter the _flights list based on the criteria
            var matchingFlights = _flights.Where(flight =>
                flight.Origin.Equals(origin, StringComparison.OrdinalIgnoreCase) &&
                flight.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase) &&
                flight.Day.Equals(day, StringComparison.OrdinalIgnoreCase)).ToList();

            return matchingFlights;
        }

        // Method to add flights to the list for testing
        public void AddFlight(Flight flight)
        {
            _flights.Add(flight);
        }
    }
}
