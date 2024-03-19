namespace Assignment_2.Data
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
            if (Enum.TryParse<DayOfWeek>(day, true, out var dayOfWeek))
            {
                var matchingFlights = _flights.Where(flight =>
                    flight.OriginAirport.Equals(origin, StringComparison.OrdinalIgnoreCase) &&
                    flight.DestinationAirport.Equals(destination, StringComparison.OrdinalIgnoreCase) &&
                    flight.Day == dayOfWeek).ToList();

                return matchingFlights;
            }
            else
            {
                return new List<Flight>();
            }
        }

        public void LoadFlightsFromCsv(string filePath)
        {
            var lines = System.IO.File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var columns = line.Split(',');

                var flight = new Flight(
                    columns[0].Trim(), // FlightCode
                    columns[1].Trim(), // Airline
                    columns[2].Trim(), // Origin
                    columns[3].Trim(), // Destination
                    Enum.Parse<Assignment_2.Data.DayOfWeek>(columns[4].Trim(), true),
                    TimeSpan.Parse(columns[5].Trim()), // Arrival Time
                    int.Parse(columns[6].Trim()), // Cost 
                    double.Parse(columns[7].Trim()) // Distance
                );

                _flights.Add(flight);
            }
        }
    }
}
